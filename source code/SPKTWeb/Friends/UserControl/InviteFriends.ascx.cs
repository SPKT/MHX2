using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SPKTWeb.Friends.Interface;
using SPKTWeb.Friends.Presenter;

namespace SPKTWeb.Friends
{
    public partial class InviteFriends : System.Web.UI.UserControl, IInviteFriends
    {
        private InviteFriendsPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new InviteFriendsPresenter();
            _presenter.Init(this);
        }

        protected void btnInvite_Click(object sender, EventArgs e)
        {
            _presenter.SendInvitation(txtTo.Text, txtMessage.Text);
        }

        public void DisplayToData(string To)
        {
            lblFrom.Text = To;
        }

        public void TogglePnlInvite(bool IsVisible)
        {
            pnlInvite.Visible = IsVisible;
        }

        public void ShowMessage(string Message)
        {
            lblMessage.Text = Message;
        }

        public void ResetUI()
        {
            txtMessage.Text = "";
            txtTo.Text = "";
        }
    }
}