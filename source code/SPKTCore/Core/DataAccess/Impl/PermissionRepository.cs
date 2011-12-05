using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.DataAccess;
using StructureMap;
using SPKTCore.Core.Domain;
/// <summary>
/// Summary description for PermissionRepository
/// </summary>
namespace SPKTCore.Core.DataAccess.Impl
{
    [Pluggable("Default")]
    public class PermissionRepository:IPermissionRepository
    {
        private Connection conn;
        public PermissionRepository()
        {
            conn= new Connection();
        }

        public List<Permission> GetPermissionsByAccountID(int AccountID)
        {
            List<Permission> returnPermissions = new List<Permission>();

            using (SPKTDataContext spktDC = conn.GetContext())
            {
                var permissions = from p in spktDC.Permissions
                                  join ap in spktDC.AccountPermissions on p.PermissionID equals ap.PermissionID
                                  join a in spktDC.Accounts on ap.AccountID equals a.AccountID
                                  where a.AccountID == AccountID
                                  select p;

                foreach (Permission permission in permissions)
                {
                    returnPermissions.Add(permission);
                }
            }

            return returnPermissions;
        }

        public Permission GetPermissionByName(string Name)
        {
            Permission result;
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                result = spktDC.Permissions.Where(p => p.Name == Name).FirstOrDefault();
            }

            return result;
        }

        public Permission GetPermissionByID(int PermissionID)
        {
            Permission result;

            using (SPKTDataContext spktDC = conn.GetContext())
            {
                result = spktDC.Permissions.Where(p => p.PermissionID == PermissionID).FirstOrDefault();
            }

            return result;
        }

        public void SavePermission(Permission permission)
        {
            using (SPKTDataContext  spktDC = conn.GetContext())
            {
                if (permission.PermissionID > 0)
                {
                    spktDC.Permissions.Attach(permission, true);
                }
                else
                {
                    spktDC.Permissions.InsertOnSubmit(permission);
                }
                spktDC.SubmitChanges();
            }
        }

        public void DeletePermission(Permission permission)
        {
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                spktDC.Permissions.Attach(permission, true);
                spktDC.Permissions.DeleteOnSubmit(permission);
                spktDC.SubmitChanges();
            }
        }
    }
}