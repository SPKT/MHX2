using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Profiles.Presenter;
using SPKTWeb.Profiles.Interface;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Profiles
{

    public partial class Test : System.Web.UI.Page,IUserProfile
    {
                UserProfilePresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new UserProfilePresenter();
            _presenter.Init(this, IsPostBack);
        }

        public void LoadAlert(List<Alert> listAlert, List<StatusUpdate> listStatus)
        {
            gvStatus.DataSource = listStatus;
            Response.Write("Binding Status<br>");
            gvStatus.DataBind();
            
        }

        public void LoadStatusControl(List<VisibilityLevel> ListVisibilityLevel, bool IsUser)
        {
            
        }
        public void Message(string message)
        {
            Response.Write(message);

        }       
        public void LoadAlertUserProfile(List<Alert> listAlert)
        {
            
        }
        
        public void DisplayAccountInfo(int viewerID,int accountID)
        {
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }

        protected void lbt_DSBB_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Friends/ShowFriend.aspx");
        }


        public void LoadAlert(List<Alert> listAlert)
        {
        }
    }
}