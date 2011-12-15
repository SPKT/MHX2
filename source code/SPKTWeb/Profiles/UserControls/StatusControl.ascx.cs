using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Profiles.Interface;
using SPKTCore.Core.Domain;
using SPKTWeb.Profiles.Presenter;

namespace SPKTWeb.Profiles.UserControls
{
    public partial class StatusControl : System.Web.UI.UserControl, IStatusControl
    {
        StatusControlPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new StatusControlPresenter();
            _presenter.Init(this);
     
        }
        public StatusControl()
        {
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //_presenter.SaveStatusUpdate(txtStatus.Text, 1);
        }

        public void LoadRange(List<VisibilityLevel> visiLevel)
        {
            foreach( VisibilityLevel vl in visiLevel)
            {

            }
        }
    }
}