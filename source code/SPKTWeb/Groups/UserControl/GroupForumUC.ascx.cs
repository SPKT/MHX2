using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Groups.UserControl
{
    public partial class GroupForumUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            litCategoryPageName.Text = category.PageName;
            litForumPageName.Text = forum.PageName;
            //linkNewThread.NavigateUrl = "/Forums/Post.aspx?IsThread=1&ForumID=" + ForumID.ToString();
            linkNewThread.NavigateUrl = "/Groups/PostGroupforum.aspx?" + "IsThread=" + 1 + "&ForumID=" + forum.ForumID + "&GroupID=" + group.GroupID+"&PostID=0";
            
            repTopics.DataSource = Threads;
            repTopics.DataBind();
        }
        public List<BoardPost> Threads { get; set; }
        public BoardCategory category { get; set; }
        public Group group { get; set; }
        public BoardForum forum { get; set; }
        protected void repTopics_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink linkViewTopic = e.Item.FindControl("linkViewTopic") as HyperLink;
                //linkViewTopic.NavigateUrl = "/Forums/" + litCategoryPageName.Text + "/" + litForumPageName.Text + "/" +
                                            //((BoardPost)e.Item.DataItem).PageName + ".aspx";
                linkViewTopic.NavigateUrl = "/Groups/ViewGroupForumPost" + ".aspx?PostID=" + ((BoardPost)e.Item.DataItem).PostID + "&GroupID=" + group.GroupID;
            }
        }
    }
}