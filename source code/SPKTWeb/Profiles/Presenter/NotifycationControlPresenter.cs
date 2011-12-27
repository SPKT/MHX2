using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core;
using SPKTCore.Core.Impl;
using SPKTCore.Core.Domain;
using SPKTWeb.Profiles.Interface;

namespace SPKTWeb.Profiles.Presenter
{
    public class NotifycationControlPresenter
    {
        private IWebContext _webContext;
        private IUserSession _userSession;
        private IRedirector _redirector;
        private INotificationService _notifycationService;
        private INotificationControl _view;
        public NotifycationControlPresenter()
        {
            _webContext = new WebContext();
            _userSession = new UserSession();
            _redirector = new Redirector();
            _notifycationService = new NotificationService();
        }
        public void Init(INotificationControl view)
        {
            _view = view;
            if (_userSession.LoggedIn)
                _view.LoadData();

        }
        public List<Notification> LoadData()
        {
            return _notifycationService.GetNotify(_userSession.CurrentUser.AccountID, 10);
            
        }
        public List<Notification> LoadAllData()
        {
            return _notifycationService.GetAllNotify(_userSession.CurrentUser.AccountID);
        }

    }
}