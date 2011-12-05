using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core;
using SPKTCore.Core.Impl;
using SPKTWeb.Homes.Interface;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;

namespace SPKTWeb.Homes.Presenter
{
    public class HomePresenter
    {
        #region fields

        IUserSession _userSession;
        IHome _view;
        IAccountService _accountService;
        IRedirector _redirector;
        Account account;
        IProfileService _profileService;
        Profile profile;
        IPrivacyService _privacyService;
        IFriendService _friendService;
        IStatusUpdateService _StatusUpdateService;
        IWebContext _webContext; 
        #endregion
     
        public HomePresenter()
        {
            _userSession = new UserSession();
            _accountService=new AccountService();
            _redirector = new Redirector();
            _profileService = new ProfileService();
                        _privacyService = new PrivacyService();
            _friendService = new FriendService();
            _StatusUpdateService = new StatusUpdateService();
            _webContext = new WebContext();
        }
        public void Init(IHome View, bool IsPostBack)
        {
            _view = View;
            List<VisibilityLevel> _listVisibilityLevel = new List<VisibilityLevel>();
            _listVisibilityLevel = _privacyService.GetListVisibilityLevel();
            if(_userSession.LoggedIn==true)
            {
                _view.LoadStatusControl(_listVisibilityLevel, true);
                account=_userSession.CurrentUser;
                if (!IsPostBack)
                    _view.LoadStatus(GetStatusToShow(account));           
            }
            else
                account=null;
            _view.DisplayCurrentAccount(account);

        }
     
        public void GotoAccountProfile()
        {
            profile=_profileService.LoadProfileByAccountID(account.AccountID);
            if (profile != null)
            {
                _redirector.Redirect("~/Profiles/UserProfile2.aspx");

            }
            else
                _redirector.Redirect("~/Profiles/ManageProfile.aspx");
        }
        public List<StatusUpdate> GetStatusToShow(Account Account)
        {
            LogUtil.Logger.Writeln("GetStatusToShow: ");
            List<Account> listFriend = new List<Account>();
            List<StatusUpdate> list = new List<StatusUpdate>();
            listFriend = _friendService.GetListFriendByAccount(Account.AccountID);
            List<StatusUpdate> listStatus = new List<StatusUpdate>();
            foreach (Account friend in listFriend)
            {
                list= _StatusUpdateService.GetStatusUpdateByID(Account, friend, true);
                listStatus.AddRange(list);
            }
            list = _StatusUpdateService.GetStatusUpdateByID(Account, Account, true);
            listStatus.AddRange(list);
            listStatus.Sort(new Comparison<StatusUpdate>((st1, st2) => st2.CreateDate.CompareTo(st1.CreateDate)));
            LogUtil.Logger.Writeln(".  - GetStatusToShow return count: "+listStatus.Count.ToString());
            return listStatus;
        }
        internal void SaveStatusUpdate(String statusContent, int range)
        {
            if (!_userSession.LoggedIn)
            {
               // _view.Message("Chưa đăng nhập");
                return;
            }
            int accountID;
            int senderID;
            senderID = _userSession.CurrentUser.AccountID;
            accountID = _webContext.AccountID;
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
            LogUtil.Logger.Writeln("SaveStatusUpdate: " + statusContent);
            _view.LoadStatus(GetStatusToShow(account));
        }

        internal void LoadStatus()
        {
            _view.LoadStatus(GetStatusToShow(account));   
        }
    }
}