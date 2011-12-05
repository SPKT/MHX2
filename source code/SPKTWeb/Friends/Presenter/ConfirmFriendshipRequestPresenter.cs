using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core;
using SPKTCore.Core.Domain;
using SPKTCore.Core.Impl;
using SPKTWeb.Friends.Interface;
using StructureMap;

namespace SPKTWeb.Friends.Presenter
{
    public class ConfirmFriendshipRequestPresenter
    {
        private IConfirmFriendshipRequest _view;
        private IWebContext _webContext;
        private IFriendInvitationRepository _friendInvitationRepository;
        private IAccountRepository _accountRepository;
        private IRedirector _redirector;

        public ConfirmFriendshipRequestPresenter()
        {            
           _webContext = new SPKTCore.Core.Impl.WebContext();
            _friendInvitationRepository = new SPKTCore.Core.DataAccess.Impl.FriendInvitationRepository();
            _accountRepository = new SPKTCore.Core.DataAccess.Impl.AccountRepository();
            _redirector = new SPKTCore.Core.Impl.Redirector();
        }

        public void Init(IConfirmFriendshipRequest view)
        {
            _view = view;
            if (!string.IsNullOrEmpty(_webContext.FriendshipRequest))
            {
                FriendInvitation friendInvitation =
                    _friendInvitationRepository.GetFriendInvitationByGUID(new Guid(_webContext.FriendshipRequest));
                if (friendInvitation != null)
                {
                    Account account = _accountRepository.GetAccountByID(friendInvitation.AccountID);
                    _view.ShowConfirmPanel(true);
                    _view.LoadDisplay(_webContext.FriendshipRequest, account.AccountID, account.UserName, "http://localhost:4120/Friends/ConfirmFriendshipRequest.aspx");
                }
                else
                {
                    _view.ShowConfirmPanel(false);
                    _view.ShowMessage("Lỗi rồi");
                }
            }
        }
        
        public void LoginClick()
        {
            _redirector.GoToAccountLoginPage(_webContext.FriendshipRequest);
        }

        public void RegisterClick()
        {
            _redirector.GoToAccountRegisterPage(_webContext.FriendshipRequest);
        }
    }
}