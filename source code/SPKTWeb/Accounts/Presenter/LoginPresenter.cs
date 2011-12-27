using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using StructureMap;
using SPKTWeb.Accounts.Interface;
using SPKTCore.Core;
using System.Web.Security;


namespace SPKTWeb.Accounts.Presenter
{
    public class LoginPresenter
    {
        private ILogin _view;
        private IAccountService _accountService;
        private IRedirector _redirector;
        private IWebContext _webContext;

        public void Init(ILogin view)
        {
            _view = view;
            _accountService = new SPKTCore.Core.Impl.AccountService();
            _redirector = new SPKTCore.Core.Impl.Redirector();
            _webContext = new SPKTCore.Core.Impl.WebContext();
            if (!string.IsNullOrEmpty(_webContext.FriendshipRequest))
                _view.DisplayMessage("Đăng nhập để xác nhận");
        }
        
        public void Login(string username, string password,bool rememberMe)
        {
            string message;
            if (_accountService.Login(username, password, rememberMe, out message))
            {
                FormsAuthentication.SetAuthCookie(username, rememberMe);
                if (_webContext.ReturnURL != null)
                    FormsAuthentication.RedirectFromLoginPage(username, true);
                else
                    _redirector.Redirect("~/Homes/home.aspx?UserName=" + username);
            }
            else
            {
                DkmhWebservice.UsrSer service = new DkmhWebservice.UsrSer();
                if (service.ValidateUser(username, password))
                {
                    if (_accountService.IsAccountExisted(username))
                        _accountService.SetLogedIn(username);
                    else
                    {
                        DkmhWebservice.users user = service.GetUserByUserName(username);
                        _accountService.ImportAccount(user.Username, user.Email);
                        _accountService.SetLogedIn(username);
                    }
                    System.Web.Security.FormsAuthentication.SetAuthCookie(username, rememberMe);
                    if (_webContext.ReturnURL != null)
                        FormsAuthentication.RedirectFromLoginPage(username, true);
                    else
                        _redirector.Redirect("~/Homes/home.aspx?UserName=" + username);
                }
            }
            _view.DisplayMessage(message);
        }

        //public void Login(string username, string password, bool rememberMe, bool UseDKMHAccount)
        //{
        //    string message;
        //    if ( UseDKMHAccount==false)
        //    {
        //        if(_accountService.Login(username, password, rememberMe, out message))
        //            _redirector.Redirect("~/Homes/home.aspx?UserName=" + username);
        //    }
        //    else
        //    {
        //        DkmhWebservice.UsrSer service = new DkmhWebservice.UsrSer();
        //        if (service.ValidateUser(username, password))
        //        {
        //            if (_accountService.IsAccountExisted(username))
        //                _accountService.SetLogedIn(username);
        //            else
        //            {
        //                DkmhWebservice.users user = service.GetUserByUserName(username);
        //                _accountService.ImportAccount(user.Username, user.Email);
        //                _accountService.SetLogedIn(username);
        //            }
        //            _redirector.Redirect("~/Homes/home.aspx?UserName=" + username);
        //        }
        //    }
        //}

        public void GoToRegister()
        {
            _redirector.GoToAccountRegisterPage();
        }

        public void GoToRecoverPassword()
        {
            _redirector.GoToAccountRecoverPasswordPage();
        }

    }
}
