using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Groups.Interface;
using SPKTWeb.Groups.Presenter;
using SPKTCore.Core;
using SPKTCore.Core.Impl;
using SPKTCore.Core.Domain;
using SPKTWeb.Groups.UserControl;

namespace SPKTWeb.Groups
{
    public partial class ViewGroup : System.Web.UI.Page, IViewGroup
    {
        private ViewGroupPresenter _presenter;
        private IFileService _fileService;
        protected void Page_Load(object sender, EventArgs e)
        {
            _fileService = new FileService();
            _presenter = new ViewGroupPresenter();
            _presenter.Init(this, IsPostBack);
        }

        public void LoadData(Group group, List<Account> accounts)
        {
            //((SiteMaster)Master).Title = group.Name;
            lblName.Text = group.Name;
            imgGroupLogo.ImageUrl = "/files/photos/" + _fileService.GetFullFilePathByFileID(group.FileID, File.Sizes.S);
            lblCreateDate.Text = group.CreateDate.ToShortDateString();
            lblUpdateDate.Text = group.UpdateDate.ToShortDateString();
            lblDescription.Text = group.Description;
           
            hylinkViewMembers.NavigateUrl = "~/Groups/ViewManageMember.aspx?GroupID=" + group.GroupID;
            reMember.DataSource = accounts;
            reMember.DataBind();
        }

        public void ShowPublic(bool Visible)
        {
            pnlPublic.Visible = Visible;
        }

        public void ShowPrivate(bool Visible)
        {
            pnlPrivate.Visible = Visible;
            pnlForum.Visible = Visible;
            pnlMember.Visible = Visible;
            lblPrivateMessage.Visible = !Visible;
        }

        public void ShowRequestMembership(bool Visible)
        {
            lbRequestMembership.Visible = Visible;
        }



        protected void lbRequestMembership_Click(object sender, EventArgs e)
        {
            _presenter.RequestMembership();
        }

        public void ShowMessage(string Message)
        {
            lblMessage.Text = Message;
        }


        protected void lblUsername_Click(object sender, EventArgs e)
        {
           
        }

        protected void reMember_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }


        public void LoadForum(BoardForum forum, List<BoardPost> threads, BoardCategory category, Group group)
        {
            uc.forum = forum;
            uc.category= category;
            uc.Threads=threads;
            uc.group = group;
            pnlForum.Controls.Add(uc);
            
        }
    }
}