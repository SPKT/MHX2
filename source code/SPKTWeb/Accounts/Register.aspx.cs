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

namespace SPKTWeb.Accounts
{
    public partial class Register : System.Web.UI.Page,IRegister
    {
        RegisterPresenter _Presenter;
        EnumObject DoiTuong = new EnumObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            _Presenter=new RegisterPresenter();
            _Presenter.Init(this);
            if (rdbCuuSinhVien.Checked == true)
                DoiTuong = EnumObject.User;
            else if (rdbGiaoVien.Checked == true)
                DoiTuong = EnumObject.User;
            else if (rdbNguoiNgoai.Checked == true)
                DoiTuong = EnumObject.OutUser;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (!this.IsValid)
                return;
            string passWord=txtPassword.Text;
            string userName = txtUserName.Text;
            string email = txtEmail.Text;
            String captCha = txtCaptCha.Text;
            _Presenter.Register(userName, passWord, email, DoiTuong,captCha);
           
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

        //protected void txtPasswordPre_TextChanged(object sender, EventArgs e)
        //{
        //    string passpre = txtPasswordPre.Text;
        //    if (_Presenter.CheckPassword(txtPasswordPre.Text, txtPassword.Text))
        //        txtPasswordPre.Text = passpre;
        //    else
        //        txtPasswordPre.Text = null;

        //}

        //protected void txtPassword_TextChanged(object sender, EventArgs e)
        //{
        //  string pass=txtPassword.Text;
        //  if (_Presenter.CheckPasswordLength(pass))
        //      txtPassword.Text = pass;
        //  else
        //      txtPassword.Text = null;
        //}

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

        
    }
}