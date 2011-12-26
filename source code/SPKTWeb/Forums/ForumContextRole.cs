using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core;
using SPKTCore.Core.Impl;

namespace SPKTWeb.Forums
{
    public class ForumContextRole
    {
        IWebContext _webContext = new WebContext();
        IForumPermissionService _forumPermissionService = new ForumPermissionService();
        public ForumContextRole()
        {             
        }
        public bool IsInRole(string RoleName)
        {
            return true;
        }
    }
}