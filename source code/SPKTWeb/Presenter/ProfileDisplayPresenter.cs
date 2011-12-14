using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTWeb.Interface;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Impl;
using SPKTCore.Core.DataAccess.Impl;

namespace SPKTWeb.Presenter
{
    public class ProfileDisplayPresenter
    {
        private IProfileDisplay _view;
        private IRedirector _redirector;
        private IFriendRepository _friendRepository;
        private IUserSession _userSession;

        public ProfileDisplayPresenter()
        {
            _redirector = new Redirector();
            _friendRepository = new FriendRepository();
            _userSession = new UserSession();
        }

        public void Init(IProfileDisplay view)
        {
            _view = view;
        }

        public void SendFriendRequest(Int32 AccountIdToInvite)
        {
            _redirector.GoToFriendsInviteFriends(AccountIdToInvite);
        }

        public void DeleteFriend(Int32 FriendID)
        {
            if (_userSession.CurrentUser != null)
            {
                _friendRepository.DeleteFriendByID(_userSession.CurrentUser.AccountID, FriendID);
                HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
    }
}