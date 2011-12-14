using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess.Impl
{
    public class BoardForumRepository : IBoardForumRepository
    {
        private Connection _conn;
        public BoardForumRepository()
        {
            _conn = new Connection();

        }
        public BoardForum GetForumByGroupID(Int32 GroupID)
        {
            BoardForum result;
            using (SPKTDataContext dc = _conn.GetContext())
            {
                BoardForum forum = (from f in dc.BoardForums
                                    join gf in dc.GroupForums on f.ForumID equals gf.ForumID
                                    where gf.GroupID == GroupID
                                    select f).FirstOrDefault();
                result = forum;
            }
            return result;
        }

        public BoardForum GetForumByID(Int32 ForumID)
        {
            BoardForum result;
            using (SPKTDataContext dc = _conn.GetContext())
            {
                BoardForum forum = dc.BoardForums.Where(f => f.ForumID == ForumID).FirstOrDefault();
                result = forum;
            }
            return result;
        }

        public BoardForum GetForumByPageName(string PageName)
        {
            BoardForum result;
            using (SPKTDataContext dc = _conn.GetContext())
            {
                BoardForum forum = dc.BoardForums.Where(f => f.PageName == PageName).FirstOrDefault();
                result = forum;
            }
            return result;
        }

        public List<BoardForum> GetForumsByCategoryID(Int32 CategoryID)
        {
            List<BoardForum> results;
            using (SPKTDataContext dc = _conn.GetContext())
            {
                IEnumerable<BoardForum> forums = dc.BoardForums.Where(f => f.CategoryID == CategoryID);
                results = forums.ToList();
            }
            return results;
        }

        public List<BoardForum> GetAllForums()
        {
            List<BoardForum> results;
            using (SPKTDataContext dc = _conn.GetContext())
            {
                IEnumerable<BoardForum> forums = dc.BoardForums;
                results = forums.ToList();
            }
            return results;
        }

        public Int32 SaveForum(BoardForum boardForum)
        {
            boardForum.UpdateDate = DateTime.Now;
            using (SPKTDataContext dc = _conn.GetContext())
            {
                if (boardForum.ForumID > 0)
                {
                    dc.BoardForums.Attach(boardForum, true);
                }
                else
                {
                    dc.BoardForums.InsertOnSubmit(boardForum);
                }
                dc.SubmitChanges();
            }
            return boardForum.ForumID;
        }

        public void DeleteForum(BoardForum boardForum)
        {
            using (SPKTDataContext dc = _conn.GetContext())
            {
                dc.BoardForums.Attach(boardForum, true);
                dc.BoardForums.DeleteOnSubmit(boardForum);
                dc.SubmitChanges();
            }
        }
    }
}
