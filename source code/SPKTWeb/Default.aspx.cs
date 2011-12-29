using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core;
using SPKTCore.Core.Impl;

namespace SPKTWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        SPKTCore.Core.Impl.Redirector re;
        IWebContext w = new WebContext();
        protected void Page_Load(object sender, EventArgs e)
        {            
            re = new SPKTCore.Core.Impl.Redirector();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            re.Redirect("~/Accounts/Register.aspx");
            //Register1.Visible = true;
        }
    }
}
