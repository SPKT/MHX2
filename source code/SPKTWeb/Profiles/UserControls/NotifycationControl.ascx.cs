using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Domain;
using SPKTWeb.Profiles.Interface;
using SPKTWeb.Profiles.Presenter;

namespace SPKTWeb.Profiles.UserControls
{
    public partial class NotifycationControl : System.Web.UI.UserControl, INotificationControl
    {
        NotifycationControlPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new NotifycationControlPresenter();
            _presenter.Init(this);
        }
        public void LoadData(List<Notification> notifications)
        {
            repNotify.DataSource = notifications;
            repNotify.DataBind();
        }
    }
}