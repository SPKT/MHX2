using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Interface;
using SPKTWeb.Presenter;
using SPKTCore.Core.Domain;

namespace SPKTWeb.UserControl
{
    public partial class ProfileDisplay : System.Web.UI.UserControl, IProfileDisplay
    {
        private ProfileDisplayPresenter _presenter;
        protected Account _account;

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ProfileDisplayPresenter();
            _presenter.Init(this);
            ibDelete.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete this friend?')");
        }

        public bool ShowDeleteButton
        {
            set
            {
                ibDelete.Visible = value;
            }
        }

        public bool ShowFriendRequestButton
        {
            set
            {
                ibInviteFriend.Visible = value;
            }
        }
        public void LoadDisplay(Account account)
        {
            _account = account;
            ibInviteFriend.Attributes.Add("FriendsID", _account.AccountID.ToString());
            ibDelete.Attributes.Add("FriendsID", _account.AccountID.ToString());
            //litAccountID.Text = account.AccountID.ToString();
            lblCreateDate.Text = account.CreateDate.ToString();
            imgAvatar.ImageUrl += "?AccountID=" + account.AccountID.ToString();
            lblUsername.Text = account.UserName;
            lblFriendID.Text = account.AccountID.ToString();
        }

        protected void lbInviteFriend_Click(object sender, EventArgs e)
        {
            _presenter = new ProfileDisplayPresenter();
            _presenter.Init(this);
            _presenter.SendFriendRequest(Convert.ToInt32(lblFriendID.Text));
        }

        protected void ibDelete_Click(object sender, EventArgs e)
        {
            _presenter = new ProfileDisplayPresenter();
            _presenter.Init(this);
            _presenter.DeleteFriend(Convert.ToInt32(lblFriendID.Text));
        }
    }
}