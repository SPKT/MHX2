using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPKTWeb.Messages
{
    public partial class MessageMange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbt_MessNew_Click(object sender, EventArgs e)
        {
            MessageNew1.Visible = true;
            LoadInbox1.Visible = false;
        }

        protected void lbt_MessTo_Click(object sender, EventArgs e)
        {
            LoadInbox1.Visible = true;
            MessageNew1.Visible = false;
        }
    }
}