using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Blogs.Interface;
using SPKTWeb.Blogs.Presenter;

namespace SPKTWeb.Blogs
{
    public partial class ViewBlog : System.Web.UI.Page, IViewBlog
    {
        ViewBlogPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ViewBlogPresenter();
            _presenter.Init(this);
        }

        public void LoadBlogs(List<SPKTCore.Core.Domain.Blog> Blogs)
        {
            gvBlogs.DataSource = Blogs;
            gvBlogs.DataBind();
        }
    }
}