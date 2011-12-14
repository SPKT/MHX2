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
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Styles
{
    public partial class RIGHT_MENU1 : System.Web.UI.UserControl
    {
        private IRedirector _redirector;
        IUserSession _usersession;
        private String path;
        FriendInvitationRepository _fi;
        WebContext _webcontext;
        AccountRepository _ac;
        FriendService _f;
        protected void Page_Load(object sender, EventArgs e)
        {
            _redirector = new Redirector();
            _usersession = new UserSession();
            _webcontext = new WebContext();
            _fi = new FriendInvitationRepository();
            _ac = new AccountRepository();
            _f = new FriendService();
            if (_usersession != null)
            {
                if (_webcontext.AccountID != _usersession.CurrentUser.AccountID && _webcontext.AccountID != 0)
                {
                    bt_add0.Visible = true;
                    bt_add.Visible = false;
                }
                else
                {
                    bt_add0.Visible = false;
                    bt_add.Visible = true;
                }
            }
            pn5.Visible = false;
        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            if (_webcontext.AccountID != _usersession.CurrentUser.AccountID && _webcontext.AccountID != 0)
            {
            }
            else
            {
            }
            pn5.Visible = true;
        }

        protected void lkbtnAllGroup_Click(object sender, EventArgs e)
        {
            _redirector.Redirect("~/Groups/ViewAllGroup.aspx");
        }

        protected void lkbtnMyGroup_Click(object sender, EventArgs e)
        {
            _redirector.Redirect("~/Groups/MyGroups.aspx");
        }

        protected void bt_add_Click(object sender, EventArgs e)
        {

        }

        protected void lkbtnCategory_Click(object sender, EventArgs e)
        {
            _redirector.Redirect("~/Forums/Forum.aspx");
        }
    }
}