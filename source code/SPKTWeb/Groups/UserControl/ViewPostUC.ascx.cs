using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Domain;
using SPKTWeb.Forums;

namespace SPKTWeb.Groups.UserControl
{
    public partial class ViewPostUC : System.Web.UI.UserControl
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData(Thread, Posts, forum, group);
        }
        public BoardPost Thread { get; set; }
        public List<BoardPost> Posts { get; set; }
        public BoardForum forum { get; set; }
        public Group group { get; set; }
        public void LoadData(BoardPost Thread, List<BoardPost> Posts, BoardForum forum, Group group)
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
            //linkReply.NavigateUrl = "/Forums/Post.aspx?PostID=" + Thread.PostID.ToString();

            linkReply.NavigateUrl = "/Groups/PostGroupforum.aspx?PostID=" + Thread.PostID.ToString() + "&IsThread=" + false  + "&ForumID=" + forum.ForumID + "&GroupID=" + group.GroupID;
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