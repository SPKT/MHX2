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
    public partial class LoginDesign : System.Web.UI.UserControl, IRecoverPassword
    {
        RecoverPasswordPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new RecoverPasswordPresenter();
            _presenter.Init(this);
        }

        public void ShowMessage(string Message)
        {
            
                lblErrorMessage.Text = Message;
            
                lblMessage.Text = Message;
            
        }

        public void ShowRecoverPasswordPanel(bool Value)
        {

            //pnlRecoverPassword.Visible = Value;

        }

        protected void btnRecoverPassword_Click(object sender, EventArgs e)
        {
            _presenter.RecoverPassword(txtEmail.Text);
        }

        protected void login_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

    }
}