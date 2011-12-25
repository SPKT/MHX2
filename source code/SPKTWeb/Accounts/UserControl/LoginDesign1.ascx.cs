using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Accounts.Interface;
using SPKTWeb.Accounts.Presenter;

namespace SPKTWeb.Accounts.UserControl
{
    public partial class LoginDesign1 : System.Web.UI.UserControl, ILogin
    {
        private LoginPresenter _Presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _Presenter = new LoginPresenter();
            _Presenter.Init(this);

            //pass.Visible = false;
        }

        public void DisplayMessage(string Message)
        {
            //Label1.Text = Message;
        }

        
        protected void lbRegister_Click(object sender, EventArgs e)
        {
            _Presenter.GoToRegister();
           //pass.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            _Presenter.Login(txtUserName.Text, txtPassword.Text, ckbAutoLogin.Checked);
            //txtPassword.Text = "";
            //txtUserName.Text = "";
            //pass.Visible = false;
        }

       

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
           //pass.Visible = false;
        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {
           // pass.Visible = false;
        }

        protected void lbRecoverPassword_Click1(object sender, EventArgs e)
        {
            //pass.Visible = true;
        }
    }
}