﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Domain;
using SPKTCore.Core.Impl;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;
using SPKTWeb.Groups.Presenter;

namespace SPKTWeb.Groups.UserControl
{
    public partial class GroupHeader : System.Web.UI.UserControl
    {
        IFileService _fileService;
        IWebContext _webContext;
        IRedirector _redirector;
        IGroupMemberRepository _groupMemberRepository;
        GroupHeaderPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _fileService = new FileService();
            LoadData(group, accounts);
            _webContext = new WebContext();
            _groupMemberRepository = new GroupMemberRepository();
            _redirector = new Redirector();
        }
        public Group group{get;set;}
        public List<Account> accounts { get; set; }
        public void LoadData(Group group, List<Account> accounts)
        {
            //((SiteMaster)Master).Title = group.Name;
            lblName.Text = group.Name;
            imgGroupLogo.ImageUrl = "/files/photos/" + _fileService.GetFullFilePathByFileID(group.FileID, File.Sizes.S);
            lblCreateDate.Text = group.CreateDate.ToShortDateString();
            lblUpdateDate.Text = group.UpdateDate.ToShortDateString();
            lblDescription.Text = group.Description;
            lblBody.Text = group.Body;
 
        }

        public void ShowPublic(bool Visible)
        {
            pnlPublic.Visible = Visible;
        }

        public void ShowPrivate(bool Visible)
        {
            pnlPrivate.Visible = Visible;
           
            lblPrivateMessage.Visible = !Visible;
        }

        public void ShowRequestMembership(bool Visible)
        {
            lbRequestMembership.Visible = Visible;
        }


        protected void lbRequestMembership_Click(object sender, EventArgs e)
        {
            RequestMembership();
        }
        public void RequestMembership()
        {
            
            if (_webContext.CurrentUser != null)
            {
                GroupMember gm = new GroupMember();
                gm.AccountID = _webContext.CurrentUser.AccountID;
                gm.GroupID = _webContext.GroupID;
                gm.CreateDate = DateTime.Now;
                gm.IsAdmin = false;
                gm.IsApproved = false;
                _groupMemberRepository.SaveGroupMember(gm);
                ShowMessage("Membership requested successfully!");
            }
        }
        public void ShowMessage(string Message)
        {
            lblMessage.Text = Message;
        }

        protected void lbViewMembers_Click(object sender, EventArgs e)
        {
            _redirector.Redirect("~/Groups/ViewManageMember.aspx?GroupID=" + _webContext.GroupID);
        }
    }
}