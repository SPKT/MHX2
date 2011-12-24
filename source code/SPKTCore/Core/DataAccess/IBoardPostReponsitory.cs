using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface IBoardPostRepository
    {
        BoardPost GetPostByPageName(string PageName);
        BoardPost GetPostByID(Int64 PostID);
        Int64 SavePost(BoardPost boardPost);
        void DeletePost(BoardPost boardPost);
        List<BoardPost> GetPostsByThreadID(Int64 ThreadID);
        List<BoardPost> GetThreadsByForumID(Int32 ForumID);
        bool CheckPostPageNameIsUnique(string PageName, int ForumID);
        void DeletePostsByForumID(int ForumID);

        BoardPost GetLastPost(long PostID);
    }
}
