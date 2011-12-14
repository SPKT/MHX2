using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core
{
    [PluginFamily("Default")]
    public interface IAccountService
    {
        bool UsernameInUse(string Username);
        bool EmailInUse(string Email);
        bool Login(string Username, string Password);
        bool Login(string Username, string Password, out String returnMessage);        
        bool Login(string Username, string Password,bool rememberMe, out String returnMessage);
        void Logout();
        void Register(Account a, string permission);
        Account GetAccountByAccountID(Int32 accountID);
        bool IsAccountExisted(string username);
        
        void ImportAccount(string username, string email);
        void SetLogedIn(string username);
    }
}
