using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Domain;
using SPKTWeb.Friends.Interface;
using SPKTWeb.Friends.Presenter;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Impl;
using SPKTCore.Core;
using SPKTWeb.Profiles.Interface;
using SPKTWeb.Profiles.Presenter;

namespace SPKTWeb.Friends.UserControl
{
    public partial class MoreFriend : System.Web.UI.UserControl
    {
       
        protected Account _account;
        protected Profile _profile;
        protected AccountRepository _ac;
        protected UserSession _usersession;
        protected IFriendInvitationRepository _fi;
        protected IFriendRepository _f;
        protected IEmail _email;
        private int acid;
        UserProfilePresenter _pr;
        IStatusUpdateService _statusService;
        long idst;
        string idac = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            _usersession = new UserSession();
            _ac = new AccountRepository();
            _pr = new UserProfilePresenter();
            _statusService = new SPKTCore.Core.Impl.StatusUpdateService();
            Friendship1.setidac(acid);
            com1.setidac(acid);
            
           // add.setidac(acid);
            mess1.setidac(acid);
            load();
            com1.setidst(idst);
            //mess1.setidac(Int32.Parse(Label3.Text));
        }
        public void load()
        {
            Account ac= _ac.GetAccountByID(acid);
            List<StatusUpdate> sta= _pr.GetStatusToShow(_usersession.CurrentUser,ac);
            Avatar.ImageUrl = "~/Image/ProfileAvatar.aspx?AccountID=" + acid;
            string sts = "";
            if (sta.Count>0)
            {
                idst = sta[0].StatusUpdateID;
                if (sts.Length > 100)
                {
                    sts = sta[0].Status.Substring(0, 100);
                    status.Text = sts + " ...";
                    date.Text = sta[0].CreateDate.ToString();
                }
                status.Text = sta[0].Status;
                date.Text = sta[0].CreateDate.ToString();
            }
            status.Text = ac.DisplayName + "Chưa đang status nào cả";
           
            Label1.Text = ac.DisplayName;
            Label2.Text = acid.ToString();
            Label3.Text = ac.AccountID.ToString();
            lb_gioithieu.Text = "Thông tin của " + ac.UserName.ToUpper();
        }
        public void setacid(int accountID)
        {
            acid = accountID;
        }
        public void setidac1(string us)
        {
            idac = us;
        }
    }
} 