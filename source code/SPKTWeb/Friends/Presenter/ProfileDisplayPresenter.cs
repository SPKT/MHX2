using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Impl;
using SPKTWeb.Friends.Interface;
using StructureMap;
using SPKTCore.Core;

namespace SPKTWeb.Friends.Presenter
{
    public class ProfileDisplayPresenter
    {
        private IProfileDisplay _view;
        private IRedirector _redirector;
        private IFriendRepository _friendRepository;
        private IUserSession _userSession;
        private IFriendService _friendservice;
        public ProfileDisplayPresenter()
        {
            _redirector = new SPKTCore.Core.Impl.Redirector();
            _friendRepository = new SPKTCore.Core.DataAccess.Impl.FriendRepository();
            _userSession = new SPKTCore.Core.Impl.UserSession();
            _friendservice = new SPKTCore.Core.Impl.FriendService();
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
        public bool TestFriend(Account account)
        {
            return _friendservice.IsFriend(account, _userSession.CurrentUser);
        }
        public bool TestFriend2(Account account)
        {
            return _friendservice.IsFriend(_userSession.CurrentUser,account);
        }
    }
}