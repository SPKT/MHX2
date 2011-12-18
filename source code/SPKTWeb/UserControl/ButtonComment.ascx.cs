using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPKTWeb.Profiles.UserControls
{
    public partial class ButtonComment : System.Web.UI.UserControl
    {
        int idac;
        long idst;
        protected void Page_Load(object sender, EventArgs e)
        {
            comment1.setidac(idac);
            comment1.setidst(idst);
            //bt_comment.Text = idac;
        }
        public void setidac(int accountID)
        {
            idac = accountID;
        }
        public void setidst(long statusID)
        {
            idst = statusID;
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}