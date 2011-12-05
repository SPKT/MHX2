using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Profiles.Interface;
using SPKTWeb.Profiles.Presenter;
using SPKTCore.Core.Domain;
using SPKTWeb.Profiles.UserControls;

namespace SPKTWeb.Profiles
{
    public partial class UserProfile : System.Web.UI.Page, IUserProfile
    {
        UserProfilePresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new UserProfilePresenter();
            _presenter.Init(this, IsPostBack);
        }

        public void LoadAlert(List<Alert> listAlert)
        {
            foreach (Alert alert in listAlert)
            {
                Panel pnl = new Panel();
                pnl.ID = "pnl"+alert.AlertID.ToString();
                Label lbl = new Label();
                lbl.ID = "lbl"+alert.AlertID.ToString();
                lbl.Text = alert.Message;
                pnl.Controls.Add(lbl);
                pnlAlert.Controls.Add(pnl);
            }
        }

        public void LoadStatusControl()
        {
            StatusControl1.Visible = true;    
        }
        public void Message(string message)
        {
            Response.Write(message);

        }       
        public void LoadAlertUserProfile(List<Alert> listAlert)
        {
            foreach (Alert alert in listAlert)
            {
                AlertControl alertControl = new AlertControl();
                alertControl.Alert = alert;
                alertControl.YesNo = true;
                pnlAlert.Controls.Add(alertControl);
            }
            //foreach (Alert alert in listAlert)
            //{
            //    Panel pnl = new Panel();
            //    pnl.ID = "pnl" + alert.AlertID.ToString();
            //    Label lbl = new Label();
            //    lbl.ID = "lbl" + alert.AlertID.ToString();
            //    lbl.Text = alert.Message;
            //    Button btn = new Button();
            //    btn.ID = "btn" + alert.AlertID.ToString();
            //    btn.Text = "Xóa";
            //    pnl.Controls.Add(lbl);
            //    pnl.Controls.Add(btn);
            //    pnlAlert.Controls.Add(pnl);
            //}
        }


        public void DisplayAccountInfo(int viewerID, int accountID)
        {
            testImage.Src = "~/Image/ProfileAvatar.aspx?AccountID=" + accountID.ToString();
        }

        protected void lbt_DSBB_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Friends/ShowFriend.aspx");
        }


        public void LoadStatusControl(List<VisibilityLevel> ListVisibilityLevel)
        {
            throw new NotImplementedException();
        }


        public void LoadAlert(List<Alert> listAlert, List<StatusUpdate> listStatus)
        {
            throw new NotImplementedException();
        }


        public void LoadStatusControl(List<VisibilityLevel> ListVisibilityLevel, bool IsUser)
        {
            throw new NotImplementedException();
        }
    }
}