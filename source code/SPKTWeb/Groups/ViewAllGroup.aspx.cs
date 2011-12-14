using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTWeb.Groups.Interface;
using SPKTWeb.Groups.Presenter;
using SPKTCore.Core.Domain;
using System.Web.UI.WebControls;


namespace SPKTWeb.Groups
{
    public partial class ViewAllGroup : System.Web.UI.Page, IGroup
    {
        private GroupPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new GroupPresenter();
            _presenter.Init(this);
        }

        public void LoadData(List<Group> groups)
        {
            lvGroups.DataSource = groups;
            lvGroups.DataBind();
        }

        public void ShowMessage(string message)
        {
            lblMessage.Text = message;
        }

        protected void lvGroups_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if(e.Item.ItemType == ListViewItemType.DataItem)
            {
                System.Web.UI.WebControls.Image imgGroupImage = e.Item.FindControl("imgGroupImage") as System.Web.UI.WebControls.Image;
                Literal litImageID = e.Item.FindControl("litImageID") as Literal;
                Literal litPageName = e.Item.FindControl("litPageName") as Literal;
                LinkButton lbPageName = e.Item.FindControl("lbPageName") as LinkButton;

                lbPageName.Attributes.Add("PageName", litPageName.Text);
                imgGroupImage.ImageUrl = "/files/photos/" + _presenter.GetImageByID(Convert.ToInt64(litImageID.Text),File.Sizes.S);
            }
        }

        protected void lbPageName_Click(object sender, EventArgs e)
        {
            LinkButton lbPageName = sender as LinkButton;
            _presenter.GoToGroup(lbPageName.Attributes["PageName"]);
        }
    }
    
}