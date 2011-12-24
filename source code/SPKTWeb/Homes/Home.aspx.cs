using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Homes.Interface;
using SPKTWeb.Homes.Presenter;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Homes
{
    public partial class Home : System.Web.UI.Page,IHome
    {
        HomePresenter _presenter;
        //string queryString;
        protected void Page_Load(object sender, EventArgs e)
        {
            LogUtil.Logger.Writeln("Page_Load: ");
            _presenter = new HomePresenter();
            _presenter.Init(this, IsPostBack);
        }

        protected void lbtnProfile_Click(object sender, EventArgs e)
        {
            _presenter.GotoAccountProfile();
        }

        public void DisplayCurrentAccount(SPKTCore.Core.Domain.Account account)
        {
            if (account != null)
            {
                lblXinChao.Text = "Xin chào: ";
                lbtnProfile.Visible = false;
                lbtnProfile.Text = account.UserName;
            }
            else
                lblXinChao.Text = "Chưa Đăng Nhập";
        }
        public void LoadStatus( List<StatusUpdate> listStatus)
        {
            LogUtil.Logger.Writeln(String.Format("<font color='red'><b>LoadStatus: PostBack:{0}</b> </font>", IsPostBack));
            gvStatus.DataSource = listStatus;
            gvStatus.DataBind();

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            LogUtil.Logger.Writeln("btnUpdate_Click()");
            if (ddlRange.Visible == false)
                _presenter.SaveStatusUpdate(txtStatus.Text, 1);
            else
                _presenter.SaveStatusUpdate(txtStatus.Text, Convert.ToInt32(ddlRange.SelectedValue));
            txtStatus.Text = "";
        }
        public void LoadStatusControl(List<VisibilityLevel> ListVisibilityLevel, bool IsUser)
        {
            pnlStatusUpdate.Visible = true;
            ddlRange.Items.Clear();
            foreach (VisibilityLevel level in ListVisibilityLevel)
            {
                ListItem li = new ListItem(level.Name, level.VisibilityLevelID.ToString());
                ddlRange.Items.Add(li);

            }
            ddlRange.Visible = IsUser;
        }

        protected void gvStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem is StatusUpdate)
            {
                StatusUpdate ud = (StatusUpdate)e.Row.DataItem;
                LogUtil.Logger.Writeln (String.Format("<font color='blue'>gvStatus_RowDataBound StatusUpdateID {0}</font>", ud.StatusUpdateID));
            }
        }

        
        protected void gvStatus_DataBinding1(object sender, EventArgs e)
        {
            LogUtil.Logger.Writeln(String.Format("<font color='yellow' >gvStatus_DataBinding</font>"));
        }

        protected void gvStatus_DataBound(object sender, EventArgs e)
        {
            LogUtil.Logger.Writeln(String.Format("gvStatus_DataBound"));
        }

        protected void gvStatus_RowCreated(object sender, GridViewRowEventArgs e)
        {
            LogUtil.Logger.Writeln(String.Format("<font color='red'>gvStatus_RowCreated DataItem '{0}'</font>", e.Row.DataItem));
            if (e.Row.DataItem is StatusUpdate)
            {
                StatusUpdate ud = (StatusUpdate)e.Row.DataItem;
                LogUtil.Logger.Writeln(String.Format(".  - <font color='blue'>gvStatus_RowCreated StatusUpdateID {0}</font>", ud.StatusUpdateID));
            }            
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            _presenter.LoadStatus();
        }

    }
}