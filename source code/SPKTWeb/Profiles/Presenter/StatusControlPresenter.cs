using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core;
using SPKTCore.Core.Domain;
using SPKTCore.Core.Impl;
using SPKTWeb.Profiles.Interface;

namespace SPKTWeb.Profiles.Presenter
{
    
    public class StatusControlPresenter
    {
        IUserSession _userSession;
        IStatusUpdateService _statusUpdateService;
        StatusUpdate status;
        Account account;
        IAccountService _accountService;
        IStatusControl _view;
        public StatusControlPresenter()
        {
            _userSession=new UserSession();
            _accountService = new AccountService();
            _statusUpdateService = new StatusUpdateService();
        }
        public void Init(IStatusControl view)
        {
            _view = view;
            if (_userSession.LoggedIn)
            {
                account = _userSession.CurrentUser;
            }
        }
        public void SaveStatusUpdate(String statusContent, int range)
        {
            status = new StatusUpdate();
            status.AccountID = account.AccountID;
            status.Status = statusContent;
            status.VisibilityLevelID = range;
            _statusUpdateService.SaveStatusUpdate(status);
        }
    }
}