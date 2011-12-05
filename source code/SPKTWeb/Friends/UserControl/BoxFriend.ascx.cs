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

namespace SPKTWeb.Friends
{
    public partial class BoxFriend : System.Web.UI.UserControl
    {
        //private ProfileDisplayPresenter _presenter;
        protected Account _account;
        protected Profile _profile;
        protected AccountRepository _ac;
        protected UserSession _usersession;
        protected IFriendInvitationRepository _fi;
        protected IFriendRepository _f;
        protected FriendService _fs;
        protected void Page_Load(object sender, EventArgs e)
        {
            _usersession = new SPKTCore.Core.Impl.UserSession();
            _fi = new SPKTCore.Core.DataAccess.Impl.FriendInvitationRepository();
            _f = new SPKTCore.Core.DataAccess.Impl.FriendRepository();
            _ac = new SPKTCore.Core.DataAccess.Impl.AccountRepository();
            _fs = new SPKTCore.Core.Impl.FriendService();
            _account = new Account();
        }
        public void load_InvtFriend(Account accounInvite)
        {
            _account = accounInvite;
            lbt_Ketban.Text = accounInvite.UserName;
        }
        protected void bt_OK_Click(object sender, EventArgs e)
        {
            Guid guid = _fi.GUID(_usersession.CurrentUser,_ac.GetAccountByUsername(lbt_Ketban.Text));
            _fs.CreateFriendFromFriendInvitation(guid, _usersession.CurrentUser);
            lbt_Ketban.Visible = false;
            bt_Cancel.Visible = false;
            bt_OK.Visible = false;
        }

        protected void bt_Cancel_Click(object sender, EventArgs e)
        {
            lbt_Ketban.Visible = false;
            bt_Cancel.Visible = false;
            bt_OK.Visible = false;
            Guid guid = _fi.GUID(_usersession.CurrentUser, _ac.GetAccountByUsername(lbt_Ketban.Text));
            _fs.DeleteFriendFromFriendInvitation(guid, _usersession.CurrentUser);
        }

        public LinkButton getLB()
        {
            return lbt_Ketban;
        }
        public void setLB(LinkButton a)
        {
            lbt_Ketban = a;
        }
        public string Username
        {
            get { return lbt_Ketban.Text;}
            set { lbt_Ketban.Text = value; }
        }
        protected void lbt_Ketban_Click(object sender, EventArgs e)
        {

        }
    }
}