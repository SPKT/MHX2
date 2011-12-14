using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Groups.UserControl
{
    public partial class ViewMemberUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            reMember.DataSource = accounts;
            reMember.DataBind();
        }
        public List<Account> accounts { get; set; }

    }
}