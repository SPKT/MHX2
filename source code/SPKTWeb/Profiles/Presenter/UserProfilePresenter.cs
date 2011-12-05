using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core;
using SPKTCore.Core.Impl;
using SPKTWeb.Profiles.Interface;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Profiles.Presenter
{
    
    public class UserProfilePresenter
    {
        IAlertService _alertService;
        IProfileService _profileService;
        IUserProfile _view;
        IUserSession _userSession;
        IWebContext _webContext;
        IAccountService _accountService;
        IRedirector _redirector;
        IPrivacyService _privacyService;
        IFriendService _friendService;
        IStatusUpdateService _StatusUpdateService;
        public UserProfilePresenter()
        {
            _alertService = new AlertService();
            _profileService = new ProfileService();
            _userSession = new UserSession();
            _webContext = new WebContext();
            _accountService = new AccountService();
            _redirector = new Redirector();
            _privacyService = new PrivacyService();
            _friendService = new FriendService();
            _StatusUpdateService = new StatusUpdateService();

        }
        public void Init(IUserProfile view,bool IsPostBack)
        {
            _view = view;
           
            //if (!IsPostBack)
            //{
                
                //Xu ly hien Alert
                #region Bỏ rồi
                //string profileID=_webContext.GetQueryStringValue("ProfileID");
                //List<Alert> listAlert = new List<Alert>();
                //    if (_userSession.LoggedIn)
                //    {
                //        _view.LoadStatusControl();
                //         if (profileID != null)
                //         {
                //             int proID = int.Parse(profileID);
                //             Profile profile = _profileService.GetProfileByProfileID(proID);
                //             if (profile != null)
                //             {
                //                 if (_userSession.CurrentUser.AccountID == profile.AccountID)
                //                 {
                //                     LoadAlertUserProfile(listAlert, _userSession.CurrentUser.AccountID);
                //                 }
                //                 else
                //                     LoadAlert(listAlert, profile.AccountID);
                //             }
                //             else
                //                 _view.Message("Không có Profile này");
                //         }
                //         else
                //         {
                //             LoadAlertUserProfile(listAlert,_userSession.CurrentUser.AccountID);
                //         } 
                #endregion
                
                int accountID=_webContext.AccountID;
                bool IsUser = false;
                List<Alert> listAlert = new List<Alert>();
                List<VisibilityLevel> _listVisibilityLevel = new List<VisibilityLevel>();
                _listVisibilityLevel = _privacyService.GetListVisibilityLevel();


                if (!IsPostBack)
                {
                    int viewerID = -1;
                    if (_userSession.LoggedIn)
                    {
                        viewerID = _userSession.CurrentUser.AccountID;
                        if (accountID == viewerID)
                        {
                            _view.DisplayAccountInfo(viewerID, accountID);
                            IsUser = true;
                        }

                    }
                    if (accountID > 0)
                    {
                        if (_userSession.LoggedIn)
                        {
                            _view.LoadStatusControl(_listVisibilityLevel, IsUser);
                            _view.DisplayAccountInfo(viewerID, accountID);
                            listAlert = _alertService.GetAlerts(_userSession.CurrentUser.AccountID, accountID);
                            _view.LoadAlert(listAlert, GetStatusToShow(_userSession.CurrentUser, _accountService.GetAccountByAccountID(accountID)));
                        }
                        else
                            _view.LoadAlert(_alertService.GetAlertsByAccountID(accountID));
                    }
                    if (accountID == 0)
                    {
                        if (viewerID != -1)
                        {
                            _view.DisplayAccountInfo(viewerID, viewerID);
                            IsUser = true;
                            _view.LoadStatusControl(_listVisibilityLevel, IsUser);
                            _view.LoadAlert(_alertService.GetAlerts(viewerID, viewerID), GetStatusToShow(_userSession.CurrentUser, _accountService.GetAccountByAccountID(viewerID)));
                        }


                    }
                }

            }
            
       //}

        internal void SaveStatusUpdate(String statusContent, int range)
        {
            if (!_userSession.LoggedIn)
            {
                _view.Message("Chưa đăng nhập");
                return;
            }
            int accountID;
            int senderID;
            senderID = _userSession.CurrentUser.AccountID;
            accountID = _webContext.AccountID;
            bool IsAccount = true;
            if (accountID != senderID)
                IsAccount = false;
            if (accountID <= 0)
                accountID = senderID;

            StatusUpdate status;
            status = new StatusUpdate();
            status.AccountID = accountID;
            status.SenderID = senderID;
            status.Status = statusContent;
            status.VisibilityLevelID = range;

            IStatusUpdateService _statusUpdateService;
            _statusUpdateService = new StatusUpdateService();
            _statusUpdateService.SaveStatusUpdate(status);
            _view.LoadAlert(_alertService.GetAlerts(senderID, accountID), _statusUpdateService.GetStatusUpdateByID( _userSession.CurrentUser,_accountService.GetAccountByAccountID(accountID), IsAccount));
        }
        public List<StatusUpdate> GetStatusToShow(Account AccountViewer, Account AccountBeingViewer)
        {
            //List<Account> listFriend = new List<Account>();
            //listFriend = _friendService.GetListFriendByAccount(AccountBeingViewer.AccountID);
            return _StatusUpdateService.GetStatusUpdateByID(AccountViewer, AccountBeingViewer, false);
            
        }

        internal void LoadStatus()
        {
            
        }
    }
}