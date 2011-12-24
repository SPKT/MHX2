using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Forums.UserControl
{
    public partial class ViewAllPost : System.Web.UI.UserControl
    {
        public Repeater repViewAllPost
        {
            get { return repTopics; }
            set { repTopics = value; }
        }
        public Literal litCatePageName
        {
            get { return litCategoryPageName; }
            set { litCategoryPageName = value; }
        }
        public Literal litForPageName
        {
            get { return litForumPageName; }
            set { litForumPageName = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void repTopics_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    HyperLink linkViewTopic = e.Item.FindControl("linkViewTopic") as HyperLink;
            //    if( linkViewTopic!=null)
            //        linkViewTopic.NavigateUrl = "/Forums/" + litCategoryPageName.Text + "/" + litForumPageName.Text + "/" +
            //                                ((BoardPost)e.Item.DataItem).PageName + ".aspx";
            //}
        }

        public void LoadForumPost(List<BoardPost> Threads, BoardForum forum)
        {            
            //UCViewAllPost.litCatePageName.Text = CategoryPageName;
            //UCViewAllPost.litForPageName.Text = ForumPageName;
            repViewAllPost.DataSource = Threads;
            repViewAllPost.DataBind();

        }
    }
}