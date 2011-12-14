using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Groups.Interface;
using SPKTWeb.Groups.Presenter;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Groups
{
    public partial class ViewGroupForumPost : System.Web.UI.Page, IViewGroupForumPost
    {
        ViewGroupForumPostPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ViewGroupForumPostPresenter();
            _presenter.Init(this, IsPostBack);
        }


        public void LoadData(Group group, List<Account> accounts)
        {
            GroupHeaderUC.accounts = accounts;
            GroupHeaderUC.group = group;
            pnlHeader.Controls.Add(GroupHeaderUC);
            ViewMemberUC.accounts = accounts;
            pnlMember.Controls.Add(ViewMemberUC);
        }

        public void ShowMessage(string Message)
        {
            GroupHeaderUC.ShowMessage(Message);
        }

        public void ShowPublic(bool Visible)
        {
            GroupHeaderUC.ShowPublic(Visible);

        }

        public void ShowPrivate(bool Visible)
        {
            GroupHeaderUC.ShowPrivate(Visible);
        }

        public void ShowRequestMembership(bool Visible)
        {
            GroupHeaderUC.ShowRequestMembership(Visible);
        }
        public void LoadDataPost(BoardPost boardPost, List<BoardPost> list, BoardForum forum, Group group)
        {
            ViewPostUC.Thread = boardPost;
            ViewPostUC.Posts = list;
            ViewPostUC.forum = forum;
            ViewPostUC.group = group;
            pnlForum.Controls.Add(ViewPostUC);
        }

    }
}