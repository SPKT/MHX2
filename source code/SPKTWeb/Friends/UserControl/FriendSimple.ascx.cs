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

namespace SPKTWeb.Friends
{
    public partial class FriendSimple : System.Web.UI.UserControl,IProfileDisplay
    {
        private ProfileDisplayPresenter _presenter;
        protected Account _account;
        protected Profile _profile;
        protected AccountRepository _ac;
        protected UserSession _usersession;
        protected IFriendInvitationRepository _fi;
        protected IFriendRepository _f;
        protected IEmail _email;
        protected void Page_Load(object sender, EventArgs e)
        {
            _usersession = new SPKTCore.Core.Impl.UserSession();
            _fi = new SPKTCore.Core.DataAccess.Impl.FriendInvitationRepository();
            _f = new SPKTCore.Core.DataAccess.Impl.FriendRepository();
            _email = new SPKTCore.Core.Impl.Email();
            _presenter = new ProfileDisplayPresenter();
            _ac = new AccountRepository();
            _presenter.Init(this);
        }
        public void LoadDisplay(Account account)
        {
            
            _account = account;
            UserNameFriend.Text = account.UserName;
        }
        
        protected void UserNameFriend_Click(object sender, EventArgs e)
        {

        }
    }
}