using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Forums.Presenter;
using SPKTWeb.Forums.Interface;
using SPKTCore.Core;
using SPKTCore.Core.Impl;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Forums
{
    public partial class ViewForum : System.Web.UI.Page, IViewForum
    {
        private ViewForumPresenter _presenter;
        protected IRedirector _redirector;
        private IWebContext _webContext;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ViewForumPresenter();
            _presenter.Init(this);
            _redirector = new Redirector();
            _webContext = new WebContext();
        }

        public void LoadDisplay(List<BoardPost> Threads, string CategoryPageName, string ForumPageName, Int32 ForumID)
        {
            litCategoryPageName.Text = CategoryPageName;
            litForumPageName.Text = ForumPageName;
            linkNewThread.NavigateUrl = "/Forums/Post.aspx?IsThread=1&ForumID=" + ForumID.ToString();
            repTopics.DataSource = Threads;
            repTopics.DataBind();
            
        }

        protected void repTopics_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink linkViewTopic = e.Item.FindControl("linkViewTopic") as HyperLink;
                linkViewTopic.NavigateUrl = "/Forums/" + litCategoryPageName.Text + "/" + litForumPageName.Text + "/" +
                                            ((BoardPost)e.Item.DataItem).PageName + ".aspx";
            }
        }
    }
}