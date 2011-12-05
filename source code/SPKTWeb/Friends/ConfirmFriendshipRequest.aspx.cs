using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using SPKTWeb.Friends.Interface;
using SPKTWeb.Friends.Presenter;

namespace SPKTWeb.Friends
{
    public partial class ConfirmFriendshipRequest : System.Web.UI.Page, IConfirmFriendshipRequest
    {
        private ConfirmFriendshipRequestPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ConfirmFriendshipRequestPresenter();
            _presenter.Init(this);
        }

        protected void lbLogin_Click(object sender, EventArgs e)
        {
            _presenter.LoginClick();
        }

        protected void lbCreateAccount_Click(object sender, EventArgs e)
        {
            _presenter.RegisterClick();
        }

        public void LoadDisplay(string FriendInvitationKey, Int32 AccountID, string Username, string SiteName)
        {
            lblFullName.Text = Username;
            lblSiteName1.Text = SiteName;
            lblSiteName2.Text = SiteName;
            imgProfileAvatar.ImageUrl = "~/Images/ALIEN_01_01.PNG";
        }

        public void ShowMessage(string Message)
        {
            lblMessage.Text = Message;
        }

        public void ShowConfirmPanel(bool value)
        {
            pnlConfirm.Visible = value;
            pnlError.Visible = !value;
        }
    }
}