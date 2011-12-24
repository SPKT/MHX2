using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Forums.Interface;
using SPKTWeb.Forums.Presenter;
using SPKTCore.Core;
using SPKTCore.Core.Impl;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Forums
{
    public partial class ViewForum1 : System.Web.UI.Page, IViewForum,IPermissionContent
    {
        private ViewForumPresenter _presenter;
        protected IRedirector _redirector;
        private IWebContext _webContext;

        #region IPermissionContent Interface

        //PermissionType _Permission;

        //public bool HasViewPermission
        //{
        //    get
        //    {
        //        return true;
        //    }
        //}

        //public bool HasEditPermission
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //public bool HasDeletePermission
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //public bool HasCreatePermission
        //{
        //    get { throw new NotImplementedException(); }
        //}

        public PermissionType Permission
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //if ((Permission & PermissionType.View )== PermissionType.View)
            //    throw new Exception("Khong được xem nội dung này, Code lại xử lý chỗ này");
            _presenter = new ViewForumPresenter();
            _redirector = new Redirector();
            _webContext = new WebContext();
            _presenter.Init(this);
            
        }

        public void LoadDisplay(List<BoardPost> Threads, string CategoryPageName, string ForumPageName, Int32 ForumID)
        {
            UCForumHeader.lblForumName.Text += ForumPageName;
            UCForumHeader.hlkDangBaiMoi.NavigateUrl = "/Forums/Post.aspx?IsThread=1&ForumID=" + ForumID.ToString();
            
            UCViewAllPost.litCatePageName.Text = CategoryPageName;
            UCViewAllPost.litForPageName.Text = ForumPageName;

            UCViewAllPost.repViewAllPost.DataSource = Threads;
            UCViewAllPost.repViewAllPost.DataBind();

        }
        public void LoadDisplay(List<BoardPost> Threads,BoardForum forum)
        {
                        
            UCForumHeader.LoadForum(forum);

            UCViewAllPost.LoadForumPost(Threads, forum);            
            
        }
        public void LoadName(BoardForum forum)
        {
        }
       /* protected void repTopics_ItemDataBound(object sender, RepeaterItemEventArgs e)
        
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink linkViewTopic = e.Item.FindControl("linkViewTopic") as HyperLink;
                linkViewTopic.NavigateUrl = "/Forums/" + litCategoryPageName.Text + "/" + litForumPageName.Text + "/" +
                                            ((BoardPost)e.Item.DataItem).PageName + ".aspx";
            }
        }*/
       }
}