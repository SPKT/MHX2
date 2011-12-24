using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPKTWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        SPKTCore.Core.Impl.Redirector re;
        protected void Page_Load(object sender, EventArgs e)
        {
            re = new SPKTCore.Core.Impl.Redirector();
            if (Register1.l == true)
                Register1.Visible = false;
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Register1.Visible = true;
        }
    }
}
