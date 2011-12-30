using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Accounts.Interface;
using SPKTWeb.Accounts.Presenter;

namespace SPKTWeb.Accounts
{
    public partial class EditAccount : System.Web.UI.Page,IEditAccount
    {
        EditAccountPresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new EditAccountPresenter();
            _presenter.Init(this,IsPostBack);
        }


        public void LoadCurrentInformation(SPKTCore.Core.Domain.Account account)
        {
            lblUserName.Text = account.UserName;
            lblOldTenHienThi.Text = account.DisplayName;
            txtTenHienThi.Text = account.DisplayName;
            lblEmail.Text = account.Email;
            
            if (account.UseAuthenticationService != null && ((bool)account.UseAuthenticationService))
            {
                rdbUseDKMH.Checked = true;
            }
            else
                rdbUseMXH.Checked = true;
            //txtEmail.Text = account.Email;
         }

        protected void btnSaveTenHienThi_Click(object sender, EventArgs e)
        {
            _presenter.SaveChangeTenHienThi(txtTenHienThi.Text);
        }

        protected void btnSavePass_Click(object sender, EventArgs e)
        {
            _presenter.SaveChangePassword(txtOlaPass.Text, txtNewPass.Text );
        }
        protected void btnSaveUserAuthentication_Click(object sender, EventArgs e)
        {            
            _presenter.SaveChangeUserAuthentication(rdbUseDKMH.Checked);
        }

        public void ShowErrorSavePass(string Message)
        {
            lblErrorpass.Text = Message;
        }

        protected void btnSaveNewEmail_Click(object sender, EventArgs e)
        {
            _presenter.SaveNewEmail(txtNewEmail.Text, txtVeriPass.Text);
        }


        public void ShowErrorSaveEmail(string Message)
        {
            lblEmailMessage.Text = Message;
        }


        public void DisplayAuthentical(bool p)
        {
            pnlUseAuthen.Visible = p;
        }


        public void ShowDisplayname(string Message)
        {
            lblDisplaynameMessage.Text = Message;
        }

        public void ShowUseAuthen(string Message)
        {
            lblUseAuthen.Text = Message;
        }
    }
}