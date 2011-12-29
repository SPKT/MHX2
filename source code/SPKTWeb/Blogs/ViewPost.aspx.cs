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
    public partial class ViewPost : System.Web.UI.Page, IViewPost
    {
        ViewPostPresenter _persenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _persenter = new ViewPostPresenter();
            _persenter.Init(this);

        }
        public void LoadPost(SPKTCore.Core.Domain.Blog blog)
        {
            lblTitle.Text = blog.Title;
            lblSubject.Text = blog.Subject;
            lblBody.Text = blog.Post;
            lblCreateDate.Text = blog.CreateDate.ToString();
            lblUpdateDate.Text = blog.UpdateDate.ToString();
            UCComments.SystemObjectRecordID = blog.BlogID;
        }

        protected void ibEdit_Click(object sender, ImageClickEventArgs e)
        {
            _persenter.GotoEditPost();
        }


        public void DisplayEdit()
        {
            ibEdit.Visible = true;
            ibDelete.Visible = true;
        }

        protected void ibDelete_Click(object sender, ImageClickEventArgs e)
        {
            _persenter.DeletePost();
            pnlViewPost.Visible = false;
            lblMessages.Text = "Bài viết đã được xóa thành công!";
        }
    }
}