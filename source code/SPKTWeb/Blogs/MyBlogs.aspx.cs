using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Blogs.Presenter;
using SPKTWeb.Blogs.Interface;

namespace SPKTWeb.Blogs
{
    public partial class MyBlogs : System.Web.UI.Page, IMyBlogs
    {
        MyBlogsPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new MyBlogsPresenter();
            _presenter.Init(this);
        }

        public void LoadBlogs(List<SPKTCore.Core.Domain.Blog> Blogs)
        {
            gvBlogs.DataSource = Blogs;
            gvBlogs.DataBind();
        }
    }
}