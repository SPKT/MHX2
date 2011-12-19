using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.DataAccess.Impl;
//using StructureMap;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    //[PluginFamily("Default")]
    public interface IAccountRepository
    {
        Account GetAccountByID(int AccountID);
        void SaveAccount(Account account);
        Account GetAccountByEmail(string Email);
        Account GetAccountByUsername(string Username);
        void AddPermission(Account account, Permission permission);
        List<Account> GetAllAccounts(Int32 PageNumber);
        List<Account> SearchAccounts(string SearchText);
        List<Account> GetApprovedAccountsByGroupID(int GroupID, int PageNumber);
        List<Account> GetAccountsToApproveByGroupID(int GroupID);
        string fullname(Int32 AccounID);
        
    }
}