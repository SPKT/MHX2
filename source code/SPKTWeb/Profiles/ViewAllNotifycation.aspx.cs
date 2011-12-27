using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Profiles.Interface;
using SPKTWeb.Profiles.Presenter;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Profiles
{
    public partial class ViewAllNotifycation : System.Web.UI.Page, INotificationControl
    {
        NotifycationControlPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new NotifycationControlPresenter();
            _presenter.Init(this);
        }
        public void LoadData()
        {
            List<Notification> notifications = _presenter.LoadAllData();
            if (notifications.Count != 0)
            {
                repNotify.DataSource = notifications;
                repNotify.DataBind();
            }
            else
                lblMessage.Text = "Chưa có tin đáng chú ý nào!";
            
        }
    }
}