using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Accounts.Interface;
using SPKTWeb.Accounts.Presenter;

namespace MXH
{
    public partial class LoginDesign : System.Web.UI.UserControl, ILogin
    {
        private LoginPresenter _Presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _Presenter = new LoginPresenter();
            _Presenter.Init(this);
        }

        public void DisplayMessage(string Message)
        {
            //Label1.Text = Message;
        }

        protected void lbRecoverPassword_Click(object sender, EventArgs e)
        {
            _Presenter.GoToRecoverPassword();
        }

        protected void lbRegister_Click(object sender, EventArgs e)
        {
            _Presenter.GoToRegister();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            _Presenter.Login(txtUserName.Text, txtPassword.Text,ckbAutoLogin.Checked);
        }
    }
}