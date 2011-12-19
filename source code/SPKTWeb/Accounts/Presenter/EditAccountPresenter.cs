using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTWeb.Accounts.Interface;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
//using StructureMap;
using SPKTCore.Core.Impl;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess.Impl;

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
        private IPermissionRepository _permissionRepository;
        public EditAccountPresenter()
        {
            _userSession = new UserSession();
            _accountRepository = new SPKTCore.Core.DataAccess.Impl.AccountRepository();
            _redirector = new Redirector();
            _accountService = new AccountService();
            _permissionRepository = new PermissionRepository();
            _email = new Email();       
        }

        public void Init(IEditAccount View, bool IsPostBack)
        {
            _view = View;
            if (_userSession.LoggedIn)
            {
                if (_userSession.CurrentUser != null)
                {
                    account = _userSession.CurrentUser;
                    List<Permission> permissions = _permissionRepository.GetPermissionsByAccountID(_userSession.CurrentUser.AccountID);
                    foreach (Permission p in permissions)
                    {
                        if (_permissionRepository.GetPermissionByName("OutSider").PermissionID == p.PermissionID)
                            _view.DisplayAuthentical(false);
                    }
                }
                else
                    _redirector.GoToAccountLoginPage();

                if (!IsPostBack)
                    LoadCurrentUser();
            }
            else
            _redirector.GoToAccountLoginPage();
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
            _view.ShowDisplayname("Thay đổi thành công");
        }

        public void SaveChangePassword(string oldPass, string newPass)
        {
            if (account.UseAuthenticationService!=null && ((bool)account.UseAuthenticationService))
            {
                try
                {
                    DkmhWebservice.UsrSer service = new DkmhWebservice.UsrSer();
                    if (service.ValidateUser(account.UserName, oldPass))
                    {
                        account.Password = newPass;
                        _accountRepository.SaveAccount(account);
                        _view.ShowErrorSavePass("Đã thay đổi thành công");
                    }
                    else
                        _view.ShowErrorSavePass("Mật khẩu nhập vào không đúng");
                }
                catch (Exception e)
                {
                    return;
                }

            }
            else

                if (account.Password.Decrypt(account.UserName) == oldPass)
                {
                    account.Password = newPass.Encrypt(account.UserName);
                    _accountRepository.SaveAccount(account);
                    _view.ShowErrorSavePass("Đã thay đổi thành công");
                }
                else
                    _view.ShowErrorSavePass("Mật khẩu cũ nhập vào không đúng");
        }

        public void SaveNewEmail(string email, string pass)
        {
            if (account.UseAuthenticationService != null && ((bool)account.UseAuthenticationService))
            {
                try
                {
                    DkmhWebservice.UsrSer service = new DkmhWebservice.UsrSer();
                    if (service.ValidateUser(account.UserName, pass))
                    {
                        account.Email = email;
                        _accountRepository.SaveAccount(account);
                        _view.ShowErrorSaveEmail("Thay đổi thành công");
                    }
                    else
                        _view.ShowErrorSaveEmail("Mật khẩu nhập vào không đúng");
                }
                catch (Exception e)
                {
                    return;
                }

            }
            else
                if (account.Password.Decrypt(account.UserName) == pass)
                {
                    account.Email = email;
                    _accountRepository.SaveAccount(account);
                    _view.ShowErrorSaveEmail("Thay đổi thành công");
                }
                else
                    _view.ShowErrorSaveEmail("Mật khẩu cũ nhập vào không đúng");
        }

        internal void SaveChangeUserAuthentication(bool p)
        {
            if (p == false && account.Password == "")
                _view.ShowUseAuthen("Bạn phải đổi mật khẩu trước khi chọn kiểu chứng thực này");
            else
            {
                account.UseAuthenticationService = p;
                _accountRepository.SaveAccount(account);
                _view.ShowUseAuthen("Thay đổi thành công");
            }
        }
    }
}