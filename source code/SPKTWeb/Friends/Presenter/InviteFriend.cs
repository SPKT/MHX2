using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTWeb.Friends.Interface;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Domain;
using SPKTCore.Core.Impl;
using SPKTCore.Core;
using StructureMap;
namespace SPKTWeb.Friends.Presenter
{
    public class InviteFriendsPresenter
    {
        private IInviteFriends _view;
        private IUserSession _userSession;
        private IEmail _email;
        private IFriendInvitationRepository _friendInvitationRepository;
        private IAccountRepository _accountRepository;
        private IWebContext _webContext;
        private Account _account;
        private Account _accountToInvite;
        
        public void Init(IInviteFriends view)
        {
            _view = view;
            //_userSession = ObjectFactory.GetInstance<IUserSession>();
            //_email = ObjectFactory.GetInstance<IEmail>();
            //_friendInvitationRepository = ObjectFactory.GetInstance<IFriendInvitationRepository>();
            //_accountRepository = ObjectFactory.GetInstance<IAccountRepository>();
            //_webContext = ObjectFactory.GetInstance<IWebContext>();
            _userSession = new SPKTCore.Core.Impl.UserSession();
            _friendInvitationRepository = new SPKTCore.Core.DataAccess.Impl.FriendInvitationRepository();
            _email = new SPKTCore.Core.Impl.Email();
            _webContext = new SPKTCore.Core.Impl.WebContext();
            if (_userSession.LoggedIn)
            {
                _account = _userSession.CurrentUser;
                _accountRepository = new SPKTCore.Core.DataAccess.Impl.AccountRepository();
                if (_account != null)
                {
                    _view.DisplayToData(_account.UserName + " &lt;" + _account.Email + "&gt;");

                    if (_webContext.AccoundIdToInvite > 0)
                    {
                        _accountToInvite = _accountRepository.GetAccountByID(_webContext.AccoundIdToInvite);

                        if (_accountToInvite != null)
                        {
                            SendInvitation(_accountToInvite.Email,
                                           _account.UserName + " " + _account.UserName + " ");
                            _view.ShowMessage(_accountToInvite.UserName + " Đã được gửi đi!");
                            _view.TogglePnlInvite(false);
                        }
                    }
                }
            }
        }

        public void SendInvitation(string ToEmailArray, string Message)
        {
            string resultMessage = "Lời mời :<BR>";
            resultMessage += _email.SendInvitations(_userSession.CurrentUser, ToEmailArray, Message);
            _view.ShowMessage(resultMessage);
            _view.ResetUI();
        }
    }
}