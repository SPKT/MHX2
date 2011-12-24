using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPKTWeb.Friends.UserControl
{
    public partial class ButtonInviteFriend : System.Web.UI.UserControl
    {
        SPKTCore.Core.Impl.Redirector re = new SPKTCore.Core.Impl.Redirector();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            re.Redirect("~/Friends/Invite.aspx");
        }
    }
}