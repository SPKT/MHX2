using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Profiles.UserControls
{
    public partial class AlertControl : System.Web.UI.UserControl
    {
        bool y;
        Alert _alert;
        protected void Page_Load(object sender, EventArgs e)
        {           

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (this.pnlAlert == null)
            {
                pnlAlert = new Panel();
                Controls.Add(pnlAlert);
            }
            if (this.pnlButton == null)
            {
                pnlButton = new Panel();
                Controls.Add(pnlButton);
            }
            if (lblContent == null)
            {
                lblContent = new Label();
                pnlAlert.Controls.Add(lblContent);
            }
            if (btnDelete == null)
            {
                btnDelete = new Button();
                btnDelete.Text = "Xoa";
                btnDelete.Click+=new EventHandler(btnDelete_Click);
                pnlButton.Controls.Add(btnDelete);
            }
        }
        public AlertControl()
        {

        }
        protected void btnDelete_Click(Object sender, EventArgs e)
        {
            this.lblContent.Text = "Đã bị xóa";
        }
        public bool YesNo
        {
            get { return y; }
            set { y = value; }
        }
        public Alert Alert
        {
            get { return _alert; }
            set { _alert = value; }
        }
    }
}