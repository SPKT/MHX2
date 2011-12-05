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
    public partial class LEFT_MENU : System.Web.UI.UserControl
    {
        private IRedirector _redirector;
        IUserSession _usersession;
        private String path;
        FriendInvitationRepository _fi;
        WebContext _webcontext;
        AccountRepository _ac;
        FriendService _f;
        public int id=0;
        public String Path
        {
             get { return path; }
             set { path = value; }
        }
        private String pathAvatar;

        public String PathAvatar
        {
            get { return pathAvatar; }
            set { pathAvatar = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            _redirector = new Redirector();
            _usersession = new UserSession();
            _webcontext=new WebContext();
            _fi=new FriendInvitationRepository();
            _ac = new AccountRepository();
            _f = new FriendService();
            Account acid;

            if (_usersession != null)
            {
                if (_webcontext.AccountID != _usersession.CurrentUser.AccountID && _webcontext.AccountID!=0)
                {
                    acid = _ac.GetAccountByID(_webcontext.AccountID);
                    lblProfileName.Text = acid.UserName;
                    lb_ban.Text = " ( " + _f.SearchFriend(acid).Count.ToString() + " )";
                    testImage.Src = "~/Image/ProfileAvatar.aspx?AccountID=" + acid.AccountID;
                    AccordionPane1.Visible = false;
                    AccordionPane3.Visible = false;
                    id = acid.AccountID;
                }
                else
                {
                    lblProfileName.Text = _usersession.CurrentUser.UserName;
                    lb_ban.Text = " ( " + _f.SearchFriend(_usersession.CurrentUser).Count.ToString() + " )";
                    testImage.Src = "~/Image/ProfileAvatar.aspx?AccountID=" + _usersession.CurrentUser.AccountID;
                    AccordionPane1.Visible = true;
                    AccordionPane3.Visible = true;
                    lb_invite.Text = " ( " + _fi.FriendInv(_usersession.CurrentUser).Count.ToString() + " )";
                    id = _usersession.CurrentUser.AccountID;
                    lb_message.Text = " ( 0 ) ";
                }
            }
        }

        protected void lbtnChangeAvatar_Click(object sender, EventArgs e)
        {
            _redirector.Redirect("~/Profiles/UploadAvatar.aspx");
        }

        protected void lbtnInfo_Click(object sender, EventArgs e)
        {
            _redirector.Redirect("~/Profiles/UploadAvatar.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            _redirector.Redirect("~/Profiles/ViewProfile.aspx?AccountID=" + id);
        }

    }
}