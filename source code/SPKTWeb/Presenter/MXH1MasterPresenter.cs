using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core;
using SPKTCore.Core.Impl;
using SPKTWeb.Interface;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Presenter
{
    public class MXH1MasterPresenter
    {
        IUserSession _userSession;
        IMXH1Master _view;
        IWebContext _webContext;
        public MXH1MasterPresenter()
        {
            _userSession = new UserSession();
            _webContext = new WebContext();
        }
        public void Init(IMXH1Master view)
        {
            _view = view;
            if (_userSession.LoggedIn)
            {
                Account account = _userSession.CurrentUser;
                _view.ShowUserName(account.UserName);
            }
            else
                _view.ShowUserName("");
        }

        internal void Logout()
        {
            _userSession.LoggedIn = false;
            _webContext.RemoveCookie("login");
            
        }
    }
}