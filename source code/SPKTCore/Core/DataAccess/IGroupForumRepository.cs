using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface IGroupForumRepository
    {
        void SaveGroupForum(GroupForum groupForum);
        void DeleteGroupForum(GroupForum groupForum);
        int GetGroupIdByForumID(int ForumID);
        void DeleteGroupForum(int ForumID, int GroupID);
    }
}
