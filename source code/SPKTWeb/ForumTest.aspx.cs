using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Forums.Interface;
using SPKTWeb.Forums.Presenter;
using SPKTCore.Core;
using SPKTCore.Core.Impl;
using SPKTCore.Core.Domain;

namespace SPKTWeb
{
    public partial class ForumTest : System.Web.UI.Page, IViewForum
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
        }

        protected void repTopics_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
        }
    }
}