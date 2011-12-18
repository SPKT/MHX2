using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Impl;
using SPKTCore.Core;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;
using SPKTWeb.Messages.Interface;
using SPKTWeb.Messages.Presenter;
using SPKTWeb.Messages.UserControl;

namespace SPKTWeb.Messages.UserControl
{
    public partial class ButtonMessage : System.Web.UI.UserControl
    {
        IWebContext _webcontext;
        IUserSession _ussersession;
        //IAccountRepository _ac;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}