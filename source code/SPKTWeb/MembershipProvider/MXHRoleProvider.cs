using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SPKTCore.Core;
using SPKTCore.Core.Impl;

namespace SPKTWeb.MembershipProvider
{
    public class MXHRoleProvider:RoleProvider
    {
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            IWebContext webContext = new WebContext();
            HttpContext.Current.Response.Write("GetRolesForUser(" + username + ")<br/><br>webContext.ForumID=" + webContext.ForumID.ToString()+"<br>");
            return new String[] { "admin" };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            IWebContext webContext = new WebContext();
            HttpContext.Current.Response.Write("IsUserInRole(" + username + "," + roleName + ")<br/><br>webContext.ForumID=" + webContext.ForumID.ToString()+"<br>");
            return true;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}