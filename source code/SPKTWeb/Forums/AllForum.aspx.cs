using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Forums.Interface;
using SPKTWeb.Forums.Presenter;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Forums
{
    public partial class AllForum : System.Web.UI.Page, IForum
    {
        private ForumPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ForumPresenter();
            _presenter.Init(this);
        }

        public void LoadCategories(List<BoardCategory> Categories)
        {
            repCategories.DataSource = Categories;
            repCategories.DataBind();
        }

        public void repCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (((BoardCategory)e.Item.DataItem).Forums != null)
                {
                    Repeater repForums = e.Item.FindControl("repForums") as Repeater;
                    repForums.DataSource = ((BoardCategory)e.Item.DataItem).Forums;
                    repForums.DataBind();
                }
            }
        }

        public void repForums_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    Literal litPageName = e.Item.FindControl("litPageName") as Literal;
            //    LinkButton lbForum = e.Item.FindControl("lbForum") as LinkButton;
            //    lbForum.Attributes.Add("ForumPageName", litPageName.Text);
            //}
        }

        public void lbForum_Click(object sender, EventArgs e)
        {
            LinkButton lbForum = sender as LinkButton;
            _presenter.GoToForum(lbForum.Attributes["ForumPageName"]);
        }
    }
}