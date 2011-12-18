using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core;
using SPKTCore.Core.Impl;
using SPKTWeb.Interface;
using SPKTWeb.Presenter;

namespace SPKTWeb
{
    public partial class MXH_NEW1 : System.Web.UI.MasterPage
    {
        private IRedirector _redirector;
        MXH1MasterPresenter _presenter;
        IUserSession _usersession;
        IWebContext _webContext;

        protected void Page_Load(object sender, EventArgs e)
        {
            _redirector = new Redirector();
            _presenter = new MXH1MasterPresenter();
            
            _usersession = new UserSession();
            _webContext = new WebContext();
            lb_dangky.Visible = false;
            lb_dangnhap.Visible = false;
        }
       
    }
}