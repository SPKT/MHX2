using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;
using SPKTWeb.Groups.Interface;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Impl;
using SPKTCore.Core.DataAccess.Impl;

namespace SPKTWeb.Groups.Presenter
{
    public class MyGroupsPresenter
    {
        private IMyGroups _view;
        private IRedirector _redirector;
        private IWebContext _webContext;
        private IGroupRepository _groupRepository;
        private IFileService _fileService;
        private IBoardForumRepository _boardForumRepository;
        private IBoardPostRepository _boardPostRepository;
        private IGroupForumRepository _groupForumRepository;
        private IGroupMemberRepository _groupMemberRepository;
        private IUserSession _usersession;
        public MyGroupsPresenter()
        {
            _redirector = new Redirector();
            _webContext = new WebContext();
            _groupRepository = new GroupRepository();
            _fileService = new FileService();
            _boardPostRepository = new BoardPostRepository();
            _boardForumRepository = new BoardForumRepository();
            _groupForumRepository = new GroupForumRepository();
            _groupMemberRepository = new GroupMemberRepository();
            _usersession = new UserSession();
        }

        public void Init(IMyGroups view)
        {
            _view = view;
            if (_usersession.LoggedIn)
                LoadData();
            else
                _redirector.GoToAccountLoginPage();
        }

        public void LoadData()
        {
            _view.LoadData(_groupRepository.GetGroupsOwnedByAccount(_webContext.CurrentUser.AccountID));
        }

        public string GetImageByID(Int64 ImageID, File.Sizes Size)
        {
            return _fileService.GetFullFilePathByFileID(ImageID, Size);
        }

        public void GoToGroup(string GroupPageName)
        {
            _redirector.GoToGroupsViewGroup(GroupPageName);
        }

        public void DeleteGroup(int GroupID)
        {
            BoardForum forum = _boardForumRepository.GetForumByGroupID(GroupID);
            if (forum != null)
            {
                _boardPostRepository.DeletePostsByForumID(forum.ForumID);
                _groupForumRepository.DeleteGroupForum(forum.ForumID, GroupID);
                _boardForumRepository.DeleteForum(forum);
            }
            _groupMemberRepository.DeleteAllGroupMembersForGroup(GroupID);
            _groupRepository.DeleteGroup(GroupID);
            LoadData();
        }

        public void EditGroup(int GroupID)
        {
            _redirector.GoToGroupsManageGroup(GroupID);
        }
    }
}