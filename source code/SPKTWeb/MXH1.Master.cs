using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Impl;
using SPKTWeb.Interface;
using SPKTWeb.Presenter;
using SPKTCore.Core;

namespace MXH
{
    public partial class MXH1 : System.Web.UI.MasterPage, IMXH1Master
    {
        IRedirector _redirector;
        MXH1MasterPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _redirector = new Redirector();
            _presenter = new MXH1MasterPresenter();
            _presenter.Init(this);
        }

        protected void bt_TimKiem_Click(object sender, EventArgs e)
        {
            _redirector = new Redirector();
            _redirector.GotoSearch(asbCity.Text);
        }

        public void ShowUserName(string userName)
        {
            if (userName == "")
                lblUserName.Text = "Khách";
            lblUserName.Text = "Xin chào " + userName.ToUpper() ;
        }

        protected void lbt_DangNhap_Click(object sender, EventArgs e)
        {
            _redirector.Redirect("~/Account/Login.aspx");
        }
    }
}