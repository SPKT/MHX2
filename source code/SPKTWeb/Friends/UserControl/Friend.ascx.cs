using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Domain;
using SPKTWeb.Friends.Interface;
using SPKTWeb.Friends.Presenter;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Impl;
using SPKTCore.Core;
namespace SPKTWeb.Friends.UserControl
{
    public partial class Friend : System.Web.UI.UserControl,IProfileDisplay
    {
        private ProfileDisplayPresenter _presenter;
        protected Account _account;
        protected Profile _profile;
        protected AccountRepository _ac;
        protected UserSession _usersession;
        protected IFriendInvitationRepository _fi;
        protected IFriendRepository _f;
        protected IEmail _email;
        protected IWebContext _webContext;
        Redirector _rediret;
        protected void Page_Load(object sender, EventArgs e)
        {
            _rediret = new Redirector();
            _usersession = new SPKTCore.Core.Impl.UserSession();
            _fi = new SPKTCore.Core.DataAccess.Impl.FriendInvitationRepository();
            _f = new SPKTCore.Core.DataAccess.Impl.FriendRepository();
            _email = new SPKTCore.Core.Impl.Email();
            _presenter = new ProfileDisplayPresenter();
            _webContext = new WebContext();
            _ac = new AccountRepository();
            _presenter.Init(this);
            Image1.ImageUrl = "~/Image/ProfileAvatar.aspx?AccountID=" + Int32.Parse(Label1.Text);
        }

        public bool ShowDeleteButton
        {
            set
            { ;}
        }

        public bool ShowFriendRequestButton
        {
            set
            { ;}
        }
        public void LoadDisplay(Account account)
        {
            _ac = new SPKTCore.Core.DataAccess.Impl.AccountRepository();
            _account = account;
            name.Text = account.UserName;
            Label1.Text = account.AccountID.ToString();
        }

    }
}