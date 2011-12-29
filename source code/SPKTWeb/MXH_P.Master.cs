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
    public partial class MXH_P : System.Web.UI.MasterPage, IMXH1Master
    {
        private IRedirector _redirector;
        MXH1MasterPresenter _presenter;
        IUserSession _usersession;
        IWebContext _webContext;
        AccountService _as;

        protected void Page_Load(object sender, EventArgs e)
        {
            _redirector = new Redirector();
            _presenter = new MXH1MasterPresenter();
            _presenter.Init(this);
            _usersession = new UserSession();
            _webContext = new WebContext();
            _as = new AccountService();
            img_av.ImageUrl = "~/Image/ProfileAvatar.aspx";
            if (_usersession != null)
            {
                lb_dangky.Visible = false;
                lb_dangnhap.Visible = false;

            }
            else
            {
                lb_dangky.Visible = true;
                lb_dangnhap.Visible = true;

            }
            lblUserName.ForeColor = System.Drawing.Color.White;
        }
        public void ShowUserName(string userName)
        {
            if (userName == "")
                lblUserName.Text = "Khách";
            lblUserName.Text = userName.ToUpper();


        }

        protected void thaydoi_Click(object sender, EventArgs e)
        {
            _redirector.Redirect("~/Accounts/EditAccount.aspx");
        }
        protected void ketnhom(object sender, EventArgs e)
        {
            _redirector.Redirect("~/Groups/ViewAllGroup.aspx");
        }
        protected void diendan(object sender, EventArgs e)
        {
            _redirector.Redirect("~/Forums/Forum.aspx");
        }
        protected void dangxuat_Click(object sender, EventArgs e)
        {
            _webContext.Logout();
            lb_dangky.Visible = true;
            lb_dangnhap.Visible = true;
        }
        protected void lb_edit_ac_Click(object sender, EventArgs e)
        {
            _redirector.Redirect("~/Messages/MessageMange.aspx");
        }
        protected void lbt_tim_Click(object sender, EventArgs e)
        {

            _redirector.GotoSearch(timkiem.Value);
        }
        protected void tim_Click(object sender, EventArgs e)
        {

            _redirector.Redirect("~/Friends/ShowFriend.aspx");
        }
        protected void lb_info_Click(object sender, EventArgs e)
        {
            _redirector.GoToHomePage();
        }

        protected void lb_account_Click(object sender, EventArgs e)
        {
            _redirector.GoToProfilesProfile();
        }

        protected void lb_profile_Click(object sender, EventArgs e)
        {
            _redirector.GoToShowFriends();
        }
        protected void lb_manageProfile_Click(object sender, EventArgs e)
        {
            _redirector.GotoManageProfile();
        }
    }
}