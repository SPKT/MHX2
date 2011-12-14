using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Forums.Presenter;
using SPKTWeb.Forums.Interface;
using SPKTCore.Core.Domain;
using SPKTCore.Core.Impl;

namespace SPKTWeb.Forums
{
    public partial class ViewPost : System.Web.UI.Page, IViewPost
    {
        private ViewPostPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ViewPostPresenter();
            _presenter.Init(this);
        }

        public void LoadData(BoardPost Thread, List<BoardPost> Posts)
        {
            linkUsername.Text = Thread.Username;
            linkUsername.NavigateUrl = "../" + Thread.Username;
            lblUpdateDate.Text = Thread.UpdateDate.ToShortDateString();
            lblCreateDate.Text = Thread.CreateDate.ToShortDateString();
            lblSubject.Text = Thread.Name;
            //lblDescription.Text = Thread.Post.Filter();
            lblSubject.Text = Thread.Name;
            lblDescription.Text = Thread.Post;
            
            imgProfile.ImageUrl = "/Image/ProfileAvatar.aspx?AccountID=" + Thread.AccountID.ToString();
            linkReply.Text = "Reply";
            linkReply.NavigateUrl = "/Forums/Post.aspx?PostID=" + Thread.PostID.ToString();

            repPosts.DataSource = Posts;
            repPosts.DataBind();
        }

        public void repPosts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

            }
        }
    }
}