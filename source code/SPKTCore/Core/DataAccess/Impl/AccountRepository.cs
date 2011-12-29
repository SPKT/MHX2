using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Domain;
using SPKTCore.Core.Impl;

/// <summary>
/// Summary description for AccountRepository
/// </summary>
namespace SPKTCore.Core.DataAccess.Impl
{

    public class AccountRepository :IAccountRepository
    {
        private Connection conn;
        private IConfiguration _configuration;
        public AccountRepository()
        {
            conn = new Connection();
            _configuration = new Configuration();

        }
        public Account GetAccountByID(int AccountID)
        {
            Account account = null;            
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                account = (from a in spktDC.Accounts
                           where a.AccountID == AccountID
                           select a).FirstOrDefault();

            }
            return account;
        }
        
        public Account GetAccountByEmail(string email)
        {
           Account account = null;
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                account = (from a in spktDC.Accounts
                           where a.Email == email
                           select a).FirstOrDefault();
            }
            return account;
        }
        public Account GetAccountByUsername(string Username)
        {
            Account account = null;
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                account = (from a in spktDC.Accounts
                           where a.UserName == Username
                           select a).FirstOrDefault();
            }
            return account;
        } 
        public void SaveAccount(Account account)
        {
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                account.LastUpdateDate = DateTime.Now;
                if (account.AccountID > 0)
                {
                    spktDC.Accounts.Attach(account, true);
                    
                }
                else
                {
                    spktDC.Accounts.InsertOnSubmit(account);
                }
                spktDC.SubmitChanges();
            }
        }
        public void DeleteAccount(Account account)
        {
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                spktDC.Accounts.DeleteOnSubmit(account);
                spktDC.SubmitChanges();
            }
        }
        public void AddPermission(Account account, Permission permission)
        {
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                AccountPermission ap = new AccountPermission();
                ap.AccountID = account.AccountID;
                ap.PermissionID = permission.PermissionID;
                spktDC.AccountPermissions.InsertOnSubmit(ap);
                spktDC.SubmitChanges();
            }

        }

        public List<Account> GetAllAccounts(int PageNumber, int PageSize)
        {
            List<Account> result = new List<Account>();

            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<Account> accounts = (from a in dc.Accounts
                                                 orderby a.UserName
                                                 select a).Skip((PageNumber - 1) * PageSize).Take(PageSize);
                result = accounts.ToList();
            }

            return result;
        }

        public List<Account> GetAllAccounts()
        {
            List<Account> result = new List<Account>();

            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<Account> accounts = (from a in dc.Accounts
                                                 orderby a.UserName
                                                 select a);
                result = accounts.ToList();
            }

            return result;
        }

        public List<Account> GetApprovedAccountsByGroupID(int GroupID, int PageNumber)
        {
            List<Account> result = null;
            using (SPKTDataContext dc = conn.GetContext())
            {
                //IEnumerable<Account> accounts = (from a in dc.Accounts
                //                                 join m in dc.GroupMembers on a.AccountID equals m.AccountID
                //                                 where m.GroupID == GroupID && m.IsApproved
                //                                 select a).Skip((_configuration.NumberOfRecordsInPage * (PageNumber - 1)))
                //                                 .Take(_configuration.NumberOfRecordsInPage);
                IEnumerable<Account> accounts = (from a in dc.Accounts
                                                 join m in dc.GroupMembers on a.AccountID equals m.AccountID
                                                 where m.GroupID == GroupID && m.IsApproved
                                                 select a).Skip((PageNumber - 1) * 10).Take(10);
                result = accounts.ToList();
            }
            return result;
        }

        public List<Account> GetAccountsToApproveByGroupID(int GroupID)
        {
            List<Account> result = null;
            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<Account> accounts = (from a in dc.Accounts
                                                 join m in dc.GroupMembers on a.AccountID equals m.AccountID
                                                 where m.GroupID == GroupID && !m.IsApproved
                                                 select a);
                result = accounts.ToList();
            }
            return result;
        }
        public List<Account> SearchAccounts(string SearchText)
        {
            List<Account> result = new List<Account>();
            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<Account> accounts = from a in dc.Accounts
                                                where (a.UserName).Contains(SearchText) ||
                                                    a.CreateDate.ToString().Contains(SearchText) ||
                                                    a.Email.Contains(SearchText)
                                                select a;
                result = accounts.ToList();
            }
            return result;
        }
        public string fullname(Int32 AccounID)
        {
            string fullnames = "";
            using (SPKTDataContext dc = conn.GetContext())
            {
                fullnames = (from a in dc.Accounts join b in dc.Profiles on a.AccountID equals b.AccountID where b.AccountID == AccounID select b.FullName).FirstOrDefault();
            }
            return fullnames;
        }

    }
}