using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using SPKTWeb.Friends.Interface;
using SPKTCore.Core.Impl;
//using StructureMap;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Friends.Presenter
{
    public class ShowFriendPresenter 
    {
        private IShowFriend _view;
        private IFriendRepository _friendRepository;
        private IUserSession _userSession;
        private FriendService _friendService;
        WebContext _webcontext;
        IAccountRepository _ac;
        public int idac;
        public ShowFriendPresenter()
        {
            _friendRepository = new SPKTCore.Core.DataAccess.Impl.FriendRepository();
            _userSession = new SPKTCore.Core.Impl.UserSession();
            _friendService = new FriendService();
            _ac = new SPKTCore.Core.DataAccess.Impl.AccountRepository();
            _webcontext = new WebContext();
        }
        public void Init(IShowFriend view)
        {
            if (_userSession.LoggedIn)
            {
                _view = view;
                LoadFriend();
            }
        }
        public void setidac(int accountID)
        {
            idac = accountID;
        }
        public void LoadFriend()
        {
            if (_userSession != null)
            {
                if (_webcontext.AccountID != _userSession.CurrentUser.AccountID && _webcontext.AccountID != 0)
                {
                    Account ac = _ac.GetAccountByID(_webcontext.AccountID);
                    _view.LoadFriend(_friendService.SearchFriend(ac));
                }
                else
                {
                    _view.LoadFriend(_friendService.SearchFriend(_userSession.CurrentUser));
                }
            }
            if (idac > 0)
            {
                Account ac = _ac.GetAccountByID(idac);
                _view.LoadFriend(_friendService.SearchFriend(ac));
            }
           
        }
        public void LoadFriend1()
        {
            if (idac > 0)
            {
                Account ac = _ac.GetAccountByID(13);
                _view.LoadFriend(_friendService.SearchFriend(ac));
            }
        }
    }
}