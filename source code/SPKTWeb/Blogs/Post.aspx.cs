using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Blogs.Interface;
using SPKTWeb.Blogs.Presenter;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Blogs
{
    public partial class Post : System.Web.UI.Page, IPost
    {
        PostPresenter _presenter;
        Blog blog;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new PostPresenter();

            _presenter.Init(this);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            blog = new Blog();
            if (litBlogID.Text != "")
                blog.BlogID = Convert.ToInt64(litBlogID.Text);
            blog.Title = txtTitle.Text;
            blog.Subject = txtSubject.Text;
            blog.PageName = txtTitle.Text;
            blog.IsPublished = ckPubic.Checked;
            blog.Post = editBody.Content;
            _presenter.SavePost(blog);
        }

        public void LoadPost(SPKTCore.Core.Domain.Blog blog)
        {
            txtTitle.Text = blog.Title;
            txtSubject.Text = blog.Subject;
            editBody.Content = blog.Post;
            ckPubic.Checked = blog.IsPublished;
            litBlogID.Text = blog.BlogID.ToString();
        }

        public void ShowError(string ErrorMessage)
        {
            throw new NotImplementedException();
        }

        protected void ibDelete_Click(object sender, ImageClickEventArgs e)
        {
            blog = new Blog();
            if (litBlogID.Text != "")
                blog.BlogID = Convert.ToInt64(litBlogID.Text);
            _presenter.Delete(blog);
        }
    }
}