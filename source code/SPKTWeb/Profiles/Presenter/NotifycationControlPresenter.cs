﻿using System;
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
            {
                LoadData();
            }
           
        }

        private void LoadData()
        {
            List<Notification> notifycations= _notifycationService.GetNotify(_userSession.CurrentUser.AccountID, 10);
            _view.LoadData(notifycations);
        }

    }
}