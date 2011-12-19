using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Impl;
using SPKTWeb.Friends.Interface;
//using StructureMap;
using SPKTCore.Core;
namespace SPKTWeb.Friends.Presenter
{
    public class BoxFriendPresenter
    {
        private IBoxFriend _view;
        private IFriendRepository _friendRepository;
        private IUserSession _userSession;
        private FriendService _friendService;
        private IFriendInvitationRepository _friendInvite;
         public BoxFriendPresenter()
        {
            _friendRepository = new SPKTCore.Core.DataAccess.Impl.FriendRepository();
            _userSession = new SPKTCore.Core.Impl.UserSession();
            _friendService = new FriendService();
            _friendInvite = new SPKTCore.Core.DataAccess.Impl.FriendInvitationRepository();
        }

         public void Init(IBoxFriend view)
         {
             if (_userSession.LoggedIn)
             {
                 _view = view;
                 load_InvtFriend();
             }
         }
        
        public void load_InvtFriend()
        {
            _view.load_InvtFriend(_friendInvite.FriendInv(_userSession.CurrentUser));
        }
    }
}