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
using System.Web.Security;

namespace SPKTWeb.Forums
{
    public partial class ViewForum1 : SecurityPageBase, IViewForum
    {
        private ViewForumPresenter _presenter;
        

        // phuong thuc cua lop SecurityPageBase

        public override PermissionType InitPermistionBeforPageLoad()
        {
            if (_webContext.ForumID <= 0)
                _redirector.GoToForums();
            return PermissionType.View;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            _presenter = new ViewForumPresenter();             
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
            UCForumHeader.lblForumName.Text += forum.Name;            
            UCForumHeader.LoadForum(forum);
            UCViewAllPost.LoadForumPost(Threads, forum);            
            
        }
        public void LoadName(BoardForum forum)
        {
        }


    }
}