using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Accounts.Interface;
using SPKTWeb.Accounts;
using SPKTWeb.Accounts.Presenter;
using SPKTCore.Core.DataAccess.Impl;

namespace SPKTWeb.Accounts.UserControl
{
    public partial class Register : System.Web.UI.UserControl,IRegister
    {
        RegisterPresenter _Presenter;
        //EnumObject DoiTuong = new EnumObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            _Presenter=new RegisterPresenter();
            _Presenter.Init(this);
            //DoiTuong = EnumObject.OutUser;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string passWord=txtPassword.Text;
            string userName = txtUserName.Text;
            string email = txtEmail.Text;
            String captCha = txtCaptCha.Text;
            _Presenter.Register(userName, passWord, email, EnumObject.OutSider, captCha);
        }

        public void ShowErrorMessage(string Message)
        {
            lblErrorMessage.Text = Message;
        }

        public void LoadEmailAddressFromFriendInvitation(string Email)
        {
            txtEmail.Text = Email;
        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            if (_Presenter.CheckUserName(txtUserName.Text))
                txtUserName.Text = username;
            else
                txtUserName.Text = null;
        }

        public void LoadMessageCheckUserName(string Message)
        {
            lblCheckUsername.Text = Message;
        }

       
        public void LoadMessagePassWord(string Message)
        {
            lblMessagepass.Text = Message;
        }
        public void LoadMessagePassWordLength(string Message)
        {
            lblMessageLegthPass.Text = Message;
        }

        protected void PasswordCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string passpre = txtPasswordPre.Text;
            string pass = txtPassword.Text;
            if (pass != passpre)
            {
                PasswordCustomValidator.ErrorMessage = "Mật khẩu nhập lại không khớp";
                args.IsValid = false;
                return;
            }

            if (!_Presenter.CheckPasswordLength(pass))
            {
                PasswordCustomValidator.ErrorMessage = "Độ dài mật khẩu chưa đạt";
                args.IsValid = false;
                return;
            }
        }

        protected void Username_CustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string username = txtUserName.Text;
            if (!_Presenter.CheckUserName(txtUserName.Text))
            {
                args.IsValid = false;
                return;
            }
        }
        public bool l;
        public bool getL()
        {
            return l;
        }
        public void setL(bool b)
        {
            l = b;
        }
        protected void btnLogin0_Click(object sender, EventArgs e)
        {
            l = true;
        }
    }
}