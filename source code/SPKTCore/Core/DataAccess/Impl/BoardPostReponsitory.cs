using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess.Impl
{
    public class BoardPostRepository : IBoardPostRepository
    {
        private Connection _conn;
        public BoardPostRepository()
        {
            _conn = new Connection();
        }

        public bool CheckPostPageNameIsUnique(string PageName)
        {
            bool result;
            using (SPKTDataContext dc = _conn.GetContext())
            {
                BoardPost bp = dc.BoardPosts.Where(p => p.PageName == PageName).FirstOrDefault();
                if (bp != null)
                    result = false;
                else
                    result = true;
            }
            return result;
        }

        public BoardPost GetPostByPageName(string PageName)
        {
            BoardPost result = null;
            using (SPKTDataContext dc = _conn.GetContext())
            {
                BoardPost post = dc.BoardPosts.Where(p => p.PageName == PageName).FirstOrDefault();
                result = post;
            }
            return result;
        }

        public BoardPost GetPostByID(Int64 PostID)
        {
            BoardPost result = null;
            using (SPKTDataContext dc = _conn.GetContext())
            {
                BoardPost post = dc.BoardPosts.Where(p => p.PostID == PostID).FirstOrDefault();
                result = post;
            }
            return result;
        }

        public List<BoardPost> GetPostsByThreadID(Int64 ThreadID)
        {
            List<BoardPost> result;
            using (SPKTDataContext dc = _conn.GetContext())
            {
                //increment the view count for this thread
                BoardPost thread = dc.BoardPosts.Where(p => p.PostID == ThreadID).FirstOrDefault();
                if (thread != null)
                    thread.ViewCount += 1;
                dc.SubmitChanges();

                IEnumerable<BoardPost> posts = dc.BoardPosts.Where(p => p.ThreadID == ThreadID && !p.IsThread).OrderBy(p => p.CreateDate);
                result = posts.ToList();
            }
            return result;
        }

        public List<BoardPost> GetThreadsByForumID(Int32 ForumID)
        {
            List<BoardPost> result;
            using (SPKTDataContext dc = _conn.GetContext())
            {
                IEnumerable<BoardPost> posts =
                    dc.BoardPosts.Where(p => p.ForumID == ForumID && p.IsThread).OrderBy(p => p.UpdateDate);
                result = posts.ToList();
            }
            result.Reverse();
            return result;
        }

        public Int64 SavePost(BoardPost boardPost)
        {
            using (SPKTDataContext dc = _conn.GetContext())
            {
                if (boardPost.PostID > 0)
                {
                    dc.BoardPosts.Attach(boardPost, true);
                }
                else
                {
                    //get the parent containers when a new post is created
                    //  to update their post counts
                    BoardCategory bc = (from c in dc.BoardCategories
                                        join f in dc.BoardForums on c.CategoryID equals f.CategoryID
                                        where f.ForumID == boardPost.ForumID
                                        select c).FirstOrDefault();
                    BoardForum bf = (from f in dc.BoardForums
                                     where f.ForumID == boardPost.ForumID
                                     select f).FirstOrDefault();

                    //update the thread count
                    if (boardPost.IsThread)
                    {
                        bc.ThreadCount = bc.ThreadCount + 1;
                        bf.ThreadCount = bf.ThreadCount + 1;
                    }
                    //update the post count
                    else
                    {
                        bc.PostCount = bc.PostCount + 1;
                        bf.PostCount = bf.PostCount + 1;

                        //update post count on thread
                        BoardPost bThread = null;
                        if (boardPost.ThreadID != 0)
                        {
                            bThread = (from p in dc.BoardPosts
                                       where p.PostID == boardPost.ThreadID
                                       select p).FirstOrDefault();
                        }
                        if (bThread != null)
                        {
                            bThread.ReplyCount = bThread.ReplyCount + 1;
                        }
                    }

                    dc.BoardPosts.InsertOnSubmit(boardPost);
                }
                dc.SubmitChanges();
            }
            return boardPost.PostID;
        }

        //CHAPTER 10
        public void DeletePostsByForumID(int ForumID)
        {
            using (SPKTDataContext dc = _conn.GetContext())
            {
                //posts have a reference to threads...so we can't delete the threads first!

                //posts first
                dc.BoardPosts.DeleteAllOnSubmit(dc.BoardPosts.Where(bp => bp.ForumID == ForumID && !bp.IsThread));
                dc.SubmitChanges();

                //threads second
                dc.BoardPosts.DeleteAllOnSubmit(dc.BoardPosts.Where(bp => bp.ForumID == ForumID));
                dc.SubmitChanges();
            }
        }

        public void DeletePost(BoardPost boardPost)
        {
            using (SPKTDataContext dc = _conn.GetContext())
            {
                dc.BoardPosts.Attach(boardPost, true);
                //if this is a thread then we need to delete all of it's children
                if (boardPost.IsThread)
                    dc.BoardPosts.DeleteAllOnSubmit(dc.BoardPosts.Where(bp => bp.ThreadID == boardPost.PostID));
                dc.BoardPosts.DeleteOnSubmit(boardPost);
                dc.SubmitChanges();
            }
        }
    }
}
