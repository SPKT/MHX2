using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess.Impl;

namespace SPKTCore.Core.Impl
{

    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepository;
        private IPermissionRepository _permissionRepository;
        private IUserSession _userSession;
        private IRedirector _redirector;
        private IEmail _email;
        private IProfileService _profileService;
        private IWebContext _webContext;
        private IFriendService _friendService;
       
        public AccountService()
        {
            _accountRepository = new SPKTCore.Core.DataAccess.Impl.AccountRepository();
            _permissionRepository = new SPKTCore.Core.DataAccess.Impl.PermissionRepository();
            _userSession = new UserSession();
            _redirector = new Redirector();
            _email = new Email();
            _profileService = new ProfileService();
            _webContext=new SPKTCore.Core.Impl.WebContext();
            _friendService = new SPKTCore.Core.Impl.FriendService();
            //friendInvitation = new FriendInvitation();
        }

        public bool UsernameInUse(string Username)
        {
            Account account = _accountRepository.GetAccountByUsername(Username);
            if (account != null)
                return true;

            return false;
        }

        public bool EmailInUse(string Email)
        {
            Account account = _accountRepository.GetAccountByEmail(Email);
            if (account != null)
                return true;

            return false;
        }

        //public void Logout()
        //{
        //    System.Web.Security.FormsAuthentication.SignOut();
        //    _webContext.RemoveFromSession("LoggedIn");
        //    _webContext.ContainsInSession("");
        //    _webContext.RemoveCookie("Login");
        //    _userSession.LoggedIn = false;
        //    _userSession.CurrentUser = null;
        //    _userSession.Username = "";
        //    _redirector.GoToAccountLoginPage();
        //}
        public void Register(Account a, string permission)
        {
            //_accountRepository.SaveAccount(a);
            Permission publicPermission = _permissionRepository.GetPermissionByName(permission);
            Permission registeredPermission = _permissionRepository.GetPermissionByName("Registered");
            Account newAccount = _accountRepository.GetAccountByUsername(a.UserName);
            
            _accountRepository.AddPermission(newAccount, publicPermission);
            _accountRepository.AddPermission(newAccount, registeredPermission);
            _email.SendEmailAddressVerificationEmail(a.UserName, a.Email);
        }
        //public bool Login(string Username, string Password, bool rememberMe, out String returnMessage)
        //{
        //    if (rememberMe == false)
        //        return Login(Username, Password,out returnMessage);
        //    IWebContext webContext = new WebContext();
        //    webContext.SaveLoginInfoToCookie(Username, Password);

        //    return Login(Username, Password, out returnMessage); 
        //}
        public bool ValidateUser(string Username, string Password)
        {
            String message;
            return ValidateUser(Username, Password, out message);
        }

        public bool ValidateUser(string Username, string Password, out String returnMessage)
        {
            
            Password = Password.Encrypt(Username);
            Account account = _accountRepository.GetAccountByUsername(Username);

            if (account != null)
            {
                
                if (account.Password == Password)
                {
                    if (account.EmailVerified)
                    {
                        returnMessage = "Đăng nhập thành công";
                        if (!string.IsNullOrEmpty(_webContext.FriendshipRequest))
                        {
                            _friendService.CreateFriendFromFriendInvitation(new Guid(_webContext.FriendshipRequest), _userSession.CurrentUser);
                        }
                        return true;
                    }
                    else
                    {
                        
                        returnMessage= @"Bạn chưa xác thực email";
                        return false;
                    }
                }
                else
                {
                    returnMessage= "Tên đăng nhập hoặc mật khẩu không đúng";
                    return false;
                }
            }

            returnMessage = "We were unable to log you in with that information!";
            return false;
        }        

        public Account GetAccountByID(Int32 AccountID)
        {
            Account account = _accountRepository.GetAccountByID(AccountID);
            //TODO:danh cho profile
            Profile profile = _profileService.LoadProfileByAccountID(AccountID);
            if (profile != null)
            {
                account.Profile = profile;
            }
            List<Permission> permissions = _permissionRepository.GetPermissionsByAccountID(AccountID);
            foreach (Permission permission in permissions)
            {
                account.AddPermission(permission);
            }

            return account;
        }



        public Account GetAccountByAccountID(int accountID)
        {
            return _accountRepository.GetAccountByID(accountID);
            
        }


        public bool IsAccountExisted(string username)
        {
            Account account = _accountRepository.GetAccountByUsername(username);
            if (account == null)
                return false;
            return true;
        }



        public void ImportAccount(string username, string email)
        {
            Account account = new Account();
            account.UserName = username;
            account.Email = email;
            account.EmailVerified = true;
            account.Password = "";
            account.DisplayName = username;
            account.UseAuthenticationService = true;
            _accountRepository.SaveAccount(account);
            Permission publicPermission = _permissionRepository.GetPermissionByName(EnumObject.User.ToString());
            Permission registeredPermission = _permissionRepository.GetPermissionByName(EnumObject.Registered.ToString());
            Account newAccount = _accountRepository.GetAccountByUsername(account.UserName);
            _accountRepository.AddPermission(newAccount, publicPermission);
            _accountRepository.AddPermission(newAccount, registeredPermission);

        }

        //public void SetLogedIn(string Username)
        //{
        //    System.Web.Security.FormsAuthentication.SetAuthCookie(Username, false);
        //    Account account = _accountRepository.GetAccountByUsername(Username);
        //    _userSession.LoggedIn = true;
        //    _userSession.Username = Username;
        //    _userSession.CurrentUser = GetAccountByID(account.AccountID);

        //}
        public Account GetAccountByUsername(string Username)
        {
            Account account = _accountRepository.GetAccountByUsername(Username);
            if (account == null)
                return null;
            Profile profile = _profileService.LoadProfileByAccountID(account.AccountID);
            if (profile != null)
            {
                account.Profile = profile;
            }
            List<Permission> permissions = _permissionRepository.GetPermissionsByAccountID(account.AccountID);
            foreach (Permission permission in permissions)
            {
                account.AddPermission(permission);
            }
            return account;
        }

    }
}
