using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core;
using SPKTCore.Core.Domain;
using SPKTCore.Core.Impl;

namespace SPKTCore.Core.DataAccess.Impl
{
    public class AccountFolderShareRepository:IAccountFolderShareRepository
    {
        private Connection conn;
        private IConfiguration _configuration;
        public AccountFolderShareRepository()
        {
            conn = new Connection();
            _configuration = new Configuration();
        }
        public AccountFolderShare GetFolderByID(Int64 id)
        {
            AccountFolderShare accountFolder = null;
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                accountFolder = (from a in spktDC.AccountFolderShares
                                 where a.AccountFolderID == id
                                 select a).FirstOrDefault();

            }
            return accountFolder;
        }
        public List<Folder> GetFolderByAccountShared(Int32 accountID)
        {

            List<Folder> result = new List<Folder>();

            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<Folder> accountFolders = (from a in dc.AccountFolderShares join b in dc.Folders on a.FolderID equals b.FolderID where a.AccountID == accountID select b);

                result = accountFolders.ToList();
            }

            return result;

        }
        public void Save(AccountFolderShare accountFolder)
        {
            using (SPKTDataContext spktDC = conn.GetContext())
            {

                if (accountFolder.AccountFolderID > 0)
                {
                    spktDC.AccountFolderShares.Attach(accountFolder, true);

                }
                else
                {
                    spktDC.AccountFolderShares.InsertOnSubmit(accountFolder);
                }
                spktDC.SubmitChanges();
            }
        }
        public void Delete(AccountFolderShare accountFolder)
        {
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                spktDC.AccountFolderShares.DeleteOnSubmit(accountFolder);
                spktDC.SubmitChanges();
            }
        }
    }
}
