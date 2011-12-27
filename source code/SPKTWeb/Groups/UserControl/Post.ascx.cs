using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Forums.Interface;
using SPKTWeb.Forums.Presenter;
using SPKTCore.Core.Domain;
using SPKTWeb.Groups.Presenter;

namespace SPKTWeb.Groups.UserControl
{
    public partial class Post : System.Web.UI.UserControl, IPost
    {
        PostForumPostPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new PostForumPostPresenter();
            _presenter.Init(this);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BoardPost post = new BoardPost();
            post.Name = txtName.Text;
            //post.PageName = txtPageName.Text;
            
            post.Post = Editor1.Content;

            _presenter.Save(post);
        }
        //not necessary
        public void SetDisplay(bool IsThread)
        {
            //txtName.Enabled = IsThread;
        }

        public void SetErrorMessage(string Message)
        {
            lblMessage.Text = Message;
        }


        public void SetData(BoardForum forum, BoardPost thread)
        {
            
        }
    }
}