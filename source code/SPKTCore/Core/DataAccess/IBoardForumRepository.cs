using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface IBoardForumRepository
    {
        BoardForum GetForumByID(Int32 ForumID);
        BoardForum GetForumByPageName(string PageName);
        List<BoardForum> GetForumsByCategoryID(Int32 CategoryID);
        Int32 SaveForum(BoardForum boardForum);
        void DeleteForum(BoardForum boardForum);
        List<BoardForum> GetAllForums();
        BoardForum GetForumByGroupID(Int32 GroupID);
    }
}
