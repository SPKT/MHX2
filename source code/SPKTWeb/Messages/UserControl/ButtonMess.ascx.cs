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
    public partial class ButtonMess : System.Web.UI.UserControl
    {
        IWebContext _webcontext;
        IRedirector _redirect;
        IUserSession _ussersession;
        IAccountRepository _ac;
        int idac;
        protected void Page_Load(object sender, EventArgs e)
        {
            _webcontext = new WebContext();
            _ussersession = new UserSession();
            _ac = new AccountRepository();
            _redirect = new Redirector();
            MessageNew1.settbTO(idac);
        }
        public void setidac(int accountID)
        {
            idac = accountID;
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (_ussersession != null)
            {
                //MessageNew1.LoadTo(_ac.GetAccountByID(idac).UserName);
                
            }
            else
            {
                _redirect.GoToAccountLoginPage();
            }
        }
    }
}