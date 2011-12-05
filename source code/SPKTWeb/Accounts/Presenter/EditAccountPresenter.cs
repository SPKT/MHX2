using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTWeb.Accounts.Interface;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using StructureMap;
using SPKTCore.Core.Impl;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Accounts.Presenter
{
    public class EditAccountPresenter
    {
        private IEditAccount _view;
        private IUserSession _userSession;
        private IAccountService _accountService;
        private IAccountRepository _accountRepository;
        private Account account;
        private IRedirector _redirector;
        private IEmail _email;

        public EditAccountPresenter()
        {
            _userSession = new UserSession();
            _accountRepository = new SPKTCore.Core.DataAccess.Impl.AccountRepository();
            _redirector = new Redirector();
            _accountService = new AccountService();
            _email = new Email();       
        }

        public void Init(IEditAccount View, bool IsPostBack)
        {
            _view = View;
            if (_userSession.LoggedIn)
            {
                if (_userSession.CurrentUser != null)
                
                    account = _userSession.CurrentUser;
                else
                    _redirector.GoToAccountLoginPage();

                if (!IsPostBack)
                    LoadCurrentUser();
            }
        }

        private void LoadCurrentUser()
        {
            _view.LoadCurrentInformation(_userSession.CurrentUser);
        }

        public void UpdateAccount(string OldPassword, string NewPassword, string Username,string DisplayName,string Email )
        {
            //TODO: chua lam
        }

        public void SaveChangeTenHienThi(string tenHienThi)
        {
            account.DisplayName = tenHienThi;
            _accountRepository.SaveAccount(account);
        }

        public void SaveChangePassword( string oldPass,  string newPass)
        {
            if (account.Password.Decrypt(account.UserName) == oldPass)
            {
                account.Password = newPass.Encrypt(account.UserName);
                _accountRepository.SaveAccount(account);
            }
            else
                _view.ShowErrorSavePass("Mật khẩu cũ nhập vào không đúng");
        }

        public void SaveNewEmail(string email, string pass)
        {
            if (account.Password.Decrypt(account.UserName) == pass)
            {
                account.Email = email;
                _accountRepository.SaveAccount(account);
            }
            else
                _view.ShowErrorSaveEmail("Mật khẩu cũ nhập vào không đúng");
        }
    }
}