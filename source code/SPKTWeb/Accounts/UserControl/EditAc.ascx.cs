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
    public partial class EditAc : System.Web.UI.UserControl,IEditAccount
    {
        EditAccountPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new EditAccountPresenter();
            _presenter.Init(this, IsPostBack);
        }


        public void LoadCurrentInformation(SPKTCore.Core.Domain.Account account)
        {
            lblUserName.Text = account.UserName;
            lblOldTenHienThi.Text = account.DisplayName;
            txtTenHienThi.Text = account.DisplayName;
            lblEmail.Text = account.Email;
            //txtDisplayName.Text = account.UserName;
            //txtEmail.Text = account.Email;
        }

        protected void btnSaveTenHienThi_Click(object sender, EventArgs e)
        {
            _presenter.SaveChangeTenHienThi(txtTenHienThi.Text);
        }
        

        protected void btnSavePass_Click(object sender, EventArgs e)
        {
            //TODO: Can lam lai
            _presenter.SaveChangePassword(txtOlaPass.Text, txtNewPass.Text);
        }


        public void ShowErrorSavePass(string Message)
        {
            lblError.Text = Message;
        }

        protected void btnSaveNewEmail_Click(object sender, EventArgs e)
        {
            _presenter.SaveNewEmail(txtNewEmail.Text, txtVeriPass.Text);
        }


        public void ShowErrorSaveEmail(string Message)
        {
            lblErrorpass.Text = Message;
        }


        public void DisplayAuthentical(bool p)
        {
            throw new NotImplementedException();
        }


        public void ShowDisplayname(string Message)
        {
            throw new NotImplementedException();
        }

        public void ShowUseAuthen(string Message)
        {
            throw new NotImplementedException();
        }
    }
}