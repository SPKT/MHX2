using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Accounts.Presenter;
using SPKTWeb.Accounts.Interface;

namespace SPKTWeb.Accounts
{
    public partial class RecoverPassword : System.Web.UI.Page, IRecoverPassword
    {
        RecoverPasswordPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new RecoverPasswordPresenter();
            _presenter.Init(this);
        }

        //protected void btnRecoverPassword_Click(object sender, EventArgs e)
        //{
        //    _presenter.RecoverPassword(txtEmail.Text);
        //}

        public void ShowMessage(string Message)
        {
            if (pnlRecoverPassword.Visible == true)
                lblErrorMessage.Text = Message;
            else
            {
                pnlMessage.Visible = true;
                lblMessage.Text = Message;
            }
        }

        public void ShowRecoverPasswordPanel(bool Value)
        {

            pnlRecoverPassword.Visible = Value;

        }

        protected void btnRecoverPassword_Click(object sender, EventArgs e)
        {
            _presenter.RecoverPassword(txtEmail.Text);
        }

    }
}