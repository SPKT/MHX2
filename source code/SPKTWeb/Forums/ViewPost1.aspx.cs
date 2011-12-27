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
    public partial class ViewPost1 : System.Web.UI.Page, IViewPost
    {
        private ViewPostPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ViewPostPresenter();
            _presenter.Init(this);
        }

        public void LoadData(BoardPost Thread, List<BoardPost> Posts)
        {
            
            UCViewpost.lkUsername.Text = Thread.Username;
            UCViewpost.lkUsername.NavigateUrl = "../" + Thread.Username;
            UCViewpost.lblCreDate.Text = Thread.UpdateDate.ToShortDateString();
            UCViewpost.lblUpdate.Text = Thread.CreateDate.ToShortDateString();
            UCViewpost.lblTilte.Text = Thread.Name;
            UCViewpost.lblDescript.Text = Thread.Post;

            UCViewpost.ImgAvatar.ImageUrl = "/Image/ProfileAvatar.aspx?AccountID=" + Thread.AccountID.ToString();
            UCViewpost.lkReply.Text = "Reply";
            UCViewpost.lkReply.NavigateUrl = "/Forums/Post.aspx?PostID=" + Thread.PostID.ToString();

            UCViewpost.repPost.DataSource = Posts;
            UCViewpost.repPost.DataBind();
        }


        public void LoadHeaderData(BoardForum forum)
        {
            UCForumHeader.LoadForum(forum);
        }
    }
}