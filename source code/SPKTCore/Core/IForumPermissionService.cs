using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core
{
    public interface IForumPermissionService
    {
        PermissionType GetPermissionForum(int AccountID, int ForumID);

    }
}
