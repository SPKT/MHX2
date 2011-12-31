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

            _presenter.Init(this,IsPostBack);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            blog = new Blog();
            if (ViewState["BlogID"] != null)
                blog.BlogID = (long)ViewState["BlogID"];            
            blog.Title = txtTitle.Text;
            blog.Subject = txtSubject.Text;
            blog.PageName = txtTitle.Text;
            blog.IsPublished = ckPubic.Checked;
            blog.Post = editBody.Content;
            if (ViewState["CreatedDate"] != null)
                blog.CreateDate = (DateTime)ViewState["CreatedDate"];
            _presenter.SavePost(blog);
        }

        public void LoadPost(SPKTCore.Core.Domain.Blog blog)
        {
            txtTitle.Text = blog.Title;
            txtSubject.Text = blog.Subject;
            editBody.Content = blog.Post;
            ckPubic.Checked = blog.IsPublished;
            //litBlogID.Text = blog.BlogID.ToString();
            ViewState["BlogID"] = blog.BlogID;
            //litCreateDate.Text = blog.CreateDate.ToString();
            ViewState["CreatedDate"] = blog.CreateDate;
        }

        public void ShowError(string ErrorMessage)
        {
            throw new NotImplementedException();
        }

        protected void ibDelete_Click(object sender, ImageClickEventArgs e)
        {
            blog = new Blog();
            if (ViewState["BlogID"] != null)
                blog.BlogID = (long)ViewState["BlogID"];
            _presenter.Delete(blog);
        }
    }
}