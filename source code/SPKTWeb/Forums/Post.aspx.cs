using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Forums.Presenter;
using SPKTWeb.Forums.Interface;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Forums
{
    public partial class Post : System.Web.UI.Page, IPost
    {
        private PostPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new PostPresenter();
            _presenter.Init(this);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BoardPost post = new BoardPost();
            post.Name = txtName.Text;
            post.PageName = txtName.Text;
           // post.Post = txtPost.Text;
            post.Post = Editor1.Content;
            
            _presenter.Save(post);
        }
        //not necessary
        public void SetDisplay(bool IsThread)
        {
            
        }

        public void SetErrorMessage(string Message)
        {
            //lblMessage.Text = Message;
        }

        public void SetData(BoardForum forum, BoardPost thread)
        {
            UcForumHeader.LoadForum(forum);
            if (thread != null)
            {
                lblName.Text = "Trả lời bài viết " + thread.Name + " !";
                txtName.Text = "Re: " + thread.Name;
            }
            else
                lblName.Text = "Đăng bài mới";
        }
    }
}