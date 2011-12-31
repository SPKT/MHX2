using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SPKTCore.Core.Domain;
using SPKTWeb.Friends.Interface;
using SPKTWeb.Friends.Presenter;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Impl;
using SPKTCore.Core;

namespace SPKTWeb.Friends
{
    public partial class FriendProfile : System.Web.UI.UserControl, IProfileDisplay
    {
        private ProfileDisplayPresenter _presenter;
        protected Account _account;
        protected Profile _profile;
        protected AccountRepository _ac;
        protected UserSession _usersession;
        protected IFriendInvitationRepository _fi;
        protected IFriendRepository _f;
        protected IEmail _email;
        IWebContext _webcontext;
        protected void Page_Load(object sender, EventArgs e)
        {
            _webcontext = new WebContext();
            _usersession = new SPKTCore.Core.Impl.UserSession();
            _fi = new SPKTCore.Core.DataAccess.Impl.FriendInvitationRepository();
            _f = new SPKTCore.Core.DataAccess.Impl.FriendRepository();
            _email = new SPKTCore.Core.Impl.Email();
            _presenter = new ProfileDisplayPresenter();
            _ac = new AccountRepository();
            _presenter.Init(this);
            btn_de.Attributes.Add("onclick", "javascript:return confirm('Ban co muon xoa bạn?')");
            if (_usersession.CurrentUser == null)
            {
                btn_add_de.Visible = false;
                btn_de.Visible = false;
                btn_ok.Visible = false;
            }
            else
            {
                if (_presenter.TestFriend(_account) == true || _presenter.TestFriend2(_account))
                {
                    btn_add_de.Visible = false;
                    btn_de.Visible = true;
                    btn_ok.Visible = false;
                    if (_webcontext.SearchText == _usersession.CurrentUser.UserName)
                    {
                        btn_de.Visible = false;

                        btn_de.BackColor = System.Drawing.Color.Gray;
                    }
                }

                else
                {
                    btn_add_de.Visible = true;
                    btn_de.Visible = false;
                    btn_ok.Visible = false;
                    if (_webcontext.SearchText == _usersession.CurrentUser.UserName)
                    {
                        btn_de.Visible = false;
                    }
                }
                imgAvatar.ImageUrl = "~/Image/ProfileAvatar.aspx?AccountID=" + Int32.Parse(lblFriendID.Text);

            }
            more1.setacid(Int32.Parse(lblFriendID.Text));
        }

        public bool ShowDeleteButton
        {
            set
            { ;}
        }

        public bool ShowFriendRequestButton
        {
            set
            { ;}
        }
        public void LoadDisplay(Account account)
        {
            IRedirector r = new Redirector();
            _ac = new SPKTCore.Core.DataAccess.Impl.AccountRepository();
            _account = account;
            lblName.Text = account.DisplayName;
            linkAvatar.HRef = r.GetProfileURL(account.UserName);
            lblUsername.Text = account.UserName;
            linkUsername.HRef = r.GetProfileURL(account.UserName);
            lblCreateDate.Text = account.CreateDate.ToString();
            lblFriendID.Text = account.AccountID.ToString();
            if (_ac.fullname(account.AccountID) == null)
            {
                lblName.Text = account.UserName;
            }
            lblemail.Text = account.Email;
        }

        protected void lbInviteFriend_Click(object sender, EventArgs e)
        {
            _presenter = new ProfileDisplayPresenter();
            _presenter.Init(this);
        }

        protected void btn_de_Click(object sender, EventArgs e)
        {
            _presenter = new ProfileDisplayPresenter();
            _presenter.Init(this);
            _presenter.DeleteFriend(Convert.ToInt32(lblFriendID.Text));
        }

        protected void btn_add_de_Click(object sender, EventArgs e)
        {
            _presenter = new ProfileDisplayPresenter();
            _presenter.Init(this);
            //moi
            _email.SendInvitations1(_usersession.CurrentUser, lblemail.Text, " Mời bạn: ");

            btn_ok.Visible = true;
            btn_add_de.Visible = false;
        }
    }
}