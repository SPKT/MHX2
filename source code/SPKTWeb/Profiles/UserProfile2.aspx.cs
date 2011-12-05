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
    public partial class UserProfile2 : System.Web.UI.Page, IUserProfile
    {
        UserProfilePresenter _presenter;
        protected override void OnInit(EventArgs e)
        {
            _presenter = new UserProfilePresenter();
            _presenter.Init(this, IsPostBack);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            _presenter.Init(this, IsPostBack);
        }
        public void LoadAlert(List<Alert> listAlert, List<StatusUpdate> listStatus)
        {
                gvStatus.DataSource = listStatus;
                gvStatus.DataBind();
                gvAlert.DataSource = listAlert;
                gvAlert.DataBind();
         }

        public void LoadStatusControl(List<VisibilityLevel> ListVisibilityLevel, bool IsUser)
        {
            pnlStatusUpdate.Visible = true;
            foreach (VisibilityLevel level in ListVisibilityLevel)
            {
                ListItem li = new ListItem(level.Name, level.VisibilityLevelID.ToString());
                ddlRange.Items.Add(li);

            }
            ddlRange.Visible = IsUser;
        }
        public void Message(string message)
        {


        }
        public void LoadAlertUserProfile(List<Alert> listAlert)
        {
            gvAlert.DataSource = listAlert;
            gvAlert.DataBind();

        }

        public void DisplayAccountInfo(int viewerID, int accountID)
        {
           // imgAvatar.Src = "~/Image/ProfileAvatar.aspx?AccountID=" + accountID.ToString();
           
             // MXH_1.menu_l.Path = "ViewProfile.aspx?AccountID=" + accountID.ToString();
             // MXH_1.menu_l.PathAvatar = "~/Image/ProfileAvatar.aspx?AccountID=" + accountID.ToString(); 
           // lnkChangeAvatar.Visible = (viewerID == accountID);
           // lnkViewProfile.HRef = "ViewProfile.aspx?AccountID=" + accountID.ToString();
           
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ddlRange.Visible == false)
                _presenter.SaveStatusUpdate(txtStatus.Text, 1);
            else
                _presenter.SaveStatusUpdate(txtStatus.Text, Convert.ToInt32(ddlRange.SelectedValue));
            txtStatus.Text = "";
        }

        protected void lbt_DSBB_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Friends/ShowFriend.aspx");
        }


        public void LoadAlert(List<Alert> listAlert)
        {
            gvAlert.DataSource = listAlert;
            gvAlert.DataBind();
        }

        protected void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            _presenter.LoadStatus();
        }
    }
}