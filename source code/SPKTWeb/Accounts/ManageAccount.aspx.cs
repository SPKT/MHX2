using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPKTWeb.Accounts
{
    public partial class ManageAccount : System.Web.UI.Page
    {
        SPKTCore.Core.Impl.Redirector re;
        protected void Page_Load(object sender, EventArgs e)
        {
            re = new SPKTCore.Core.Impl.Redirector();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            re.Redirect("~/Accounts/Register.aspx");
        }
    }
}