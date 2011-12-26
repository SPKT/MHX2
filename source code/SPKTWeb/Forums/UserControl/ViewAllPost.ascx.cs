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

        public void LoadForumPost(List<BoardPost> Threads, BoardForum forum)
        {            
            repViewAllPost.DataSource = Threads;
            repViewAllPost.DataBind();

        }
    }
}