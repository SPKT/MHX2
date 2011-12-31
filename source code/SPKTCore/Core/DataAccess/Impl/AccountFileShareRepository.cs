using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Domain;
using SPKTCore.Core.Impl;

namespace SPKTCore.Core.DataAccess.Impl
{
    public class AccountFileShareRepository:IAccountFileShareRepository
    {
        private Connection conn;
        private IConfiguration _configuration;
        public AccountFileShareRepository()
        {
            conn = new Connection();
            _configuration = new Configuration();
           
        }
        public AccountFileShare GetFileByID(Int64 id)
        {
            AccountFileShare accountfile = null;
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                accountfile = (from a in spktDC.AccountFileShares
                           where a.AccountFileID == id
                           select a).FirstOrDefault();

            }
            return accountfile;
        }
        public List<File> GetFolderByAccountShared(Int32 accountID)
        {
            
            List<File> result = new List<File>();

            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<File> accountfiles = (from a in dc.AccountFileShares join b in dc.Files on a.FileID equals b.FileID where a.AccountID==accountID  select b);

                result = accountfiles.ToList();
            }

            return result;
       
        }
        public void Save(AccountFileShare accountfile)
        {
            using (SPKTDataContext spktDC = conn.GetContext())
            {

                if (accountfile.AccountFileID > 0)
                {
                    spktDC.AccountFileShares.Attach(accountfile, true);

                }
                else
                {
                    spktDC.AccountFileShares.InsertOnSubmit(accountfile);
                }
                spktDC.SubmitChanges();
            }
        }
        public void Delete(AccountFileShare accountfile)
        {
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                spktDC.AccountFileShares.DeleteOnSubmit(accountfile);
                spktDC.SubmitChanges();
            }
        }
    }
}
