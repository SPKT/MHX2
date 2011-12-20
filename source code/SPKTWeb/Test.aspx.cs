using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Domain;

namespace SPKTWeb
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            IAccountRepository rs = ObjectFactory.GetInstance<IAccountRepository>();
            //Response.Write("So thanh vien la: " + rs.GetAllAccounts(0).Count.ToString());

        }
    }
}