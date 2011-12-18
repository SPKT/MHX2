using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Impl;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Friends.UserControl
{
    public partial class ButtonAddFriend : System.Web.UI.UserControl
    {
        IEmail _email;
        IUserSession _usersession;
        IWebContext _webcontext;
        IAccountRepository _ac;
        protected void Page_Load(object sender, EventArgs e)
        {
            _email = new SPKTCore.Core.Impl.Email();
            _usersession = new SPKTCore.Core.Impl.UserSession();
            _webcontext = new WebContext();
            _ac = new AccountRepository();
            bt_invite.Text = "Gửi lời mời bạn";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Account a = _ac.GetAccountByID(_webcontext.AccountID);
            bt_invite.Text = "Đã gửi lời mời";
            bt_invite.ForeColor = System.Drawing.Color.Maroon;
            _email.SendInvitations1(_usersession.CurrentUser, a.Email, " Mời bạn: ");
        }
    }
}