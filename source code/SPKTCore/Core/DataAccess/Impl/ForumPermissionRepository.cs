using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess.Impl
{
    public class ForumPermissionRepository
    {
        private Connection _conn;
        public ForumPermissionRepository()
        {
            _conn = new Connection();

        }
        public Int32 AddForumAdmin(ForumAdmin forumAdmin)
        {
            
            using (SPKTDataContext dc = _conn.GetContext())
            {
                if (forumAdmin.ForumID > 0)
                {
                    dc.ForumAdmins.Attach(forumAdmin, true);
                }
                else
                {
                    dc.ForumAdmins.InsertOnSubmit(forumAdmin);
                }
                dc.SubmitChanges();
            }
            return forumAdmin.ForumAdminID;
        }

        public void DeleteForumAdmin(ForumAdmin forumAdmin)
        {
            using (SPKTDataContext dc = _conn.GetContext())
            {
                dc.ForumAdmins.Attach(forumAdmin, true);
                dc.ForumAdmins.DeleteOnSubmit(forumAdmin);
                dc.SubmitChanges();
            }
        }
    }
}
