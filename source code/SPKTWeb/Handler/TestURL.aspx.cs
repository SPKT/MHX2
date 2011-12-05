using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPKTWeb.Handler
{
    public partial class TestURL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(String.Format("PhysicalPath: {0}<br>",Request.PhysicalPath));
            Response.Write(String.Format("Path: {0}<br>", Request.Path));

        }
    }
}