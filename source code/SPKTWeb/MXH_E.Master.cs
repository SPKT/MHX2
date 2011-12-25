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
    public partial class MXH_E : System.Web.UI.MasterPage, IMXH1Master
    {
        private IRedirector _redirector;
        MXH1MasterPresenter _presenter;
        IUserSession _usersession;
        IWebContext _webContext;

        protected void Page_Load(object sender, EventArgs e)
        {
            _redirector = new Redirector();
            _presenter = new MXH1MasterPresenter();
            _presenter.Init(this);
            _usersession = new UserSession();
            _webContext = new WebContext();

        }
        public void ShowUserName(string userName)
        {
            if (userName == "")
            {
                lblUserName.Text = "Chưa đăng nhập";
                img_1.Visible = false;
                img_av.Visible = false;
            }
            else
            {
                lblUserName.Text = "Xin chào " + userName.ToUpper();
                img_av.ImageUrl = "/Image/ProfileAvatar.aspx";
                
            }
        }

        protected void thaydoi_Click(object sender, EventArgs e)
        {
            _redirector.Redirect("~/Accounts/EditAccount.aspx");
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

        protected void dangxuat_Click(object sender, EventArgs e)
        {
            SPKTCore.Core.Impl.AccountService ac = new AccountService();
            ac.Logout();
            _redirector.Redirect("~/Default.aspx");
        }

        protected void lb_thoat_Click(object sender, EventArgs e)
        {
            SPKTCore.Core.Impl.AccountService ac = new AccountService();
            ac.Logout();
            _redirector.Redirect("~/Default.aspx");
        }

        protected void lb_thaydoi_Click(object sender, EventArgs e)
        {
            _redirector.Redirect("~/Accounts/EditAccount.aspx");
        }
    }
}