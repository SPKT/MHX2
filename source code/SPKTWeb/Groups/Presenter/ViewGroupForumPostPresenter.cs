using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core;
using SPKTWeb.Groups.Interface;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Impl;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Groups.Presenter
{
    public class ViewGroupForumPostPresenter
    {
        private IWebContext _webContext;
        private IGroupRepository _groupRepository;
        private IViewGroupForumPost _view;
        private IRedirector _redirector;
        private IBoardForumRepository _boardForumRepository;
        private IBoardPostRepository _boardPostRepository;
        private IBoardCategoryRepository _boardCategoryRepository;
        private IGroupMemberRepository _groupMemberRepository;
        private IGroupService _groupService;
        public ViewGroupForumPostPresenter()
        {
            _groupRepository = new GroupRepository();
            _webContext = new WebContext();
            _redirector = new Redirector();
            _boardForumRepository = new BoardForumRepository();
            _boardCategoryRepository = new BoardCategoryRepository();
            _groupMemberRepository = new GroupMemberRepository();
            _groupService = new GroupService();
            _boardPostRepository = new BoardPostRepository();
        }

        public void Init(IViewGroupForumPost view, bool IsPostBack)
        {
            _view = view;
            //if(!IsPostBack && _webContext.GroupID > 0)
                LoadData();
        }

        public void LoadData()
        {
            Group group = _groupRepository.GetGroupByID(_webContext.GroupID);
            if (group != null)
            {
                List<Account> accounts = _groupService.GetAllMemberByGroupID(group.GroupID);
                _view.LoadData(group, accounts);

                if (_webContext.CurrentUser != null)
                    _view.ShowRequestMembership(true);
                else
                    _view.ShowRequestMembership(false);

                //is this public or private data?
                if (group.IsPublic)
                {
                    _view.ShowPrivate(true);
                    _view.ShowPublic(true);
                }
                else if (ViewerIsMember())
                {
                    _view.ShowPrivate(true);
                    _view.ShowPublic(true);
                }
                else
                {
                    _view.ShowPrivate(false);
                    _view.ShowPublic(true);
                }
                BoardForum forum = _boardForumRepository.GetForumByGroupID(group.GroupID);
                BoardCategory category = _boardCategoryRepository.GetCategoryByPageName("Group Forum");
                List<BoardPost> threads = _boardPostRepository.GetThreadsByForumID(forum.ForumID);
                //_view.LoadForum(forum,threads,category);
                _view.LoadDataPost(_boardPostRepository.GetPostByID(_webContext.PostID), _boardPostRepository.GetPostsByThreadID(_webContext.PostID), forum, group);
            }
            else
                _redirector.Redirect("~/Groups/ViewAllGroup.aspx");

            
        }

        public void GoToForum()
        {
            BoardForum forum = _boardForumRepository.GetForumByGroupID(_webContext.GroupID);
            BoardCategory category = _boardCategoryRepository.GetCategoryByCategoryID(forum.CategoryID);
            _redirector.GoToForumsForumView(forum.PageName,category.PageName);
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
               // _view.ShowMessage("Membership requested successfully!");
            }
        }

        public void ViewMembers()
        {
            _redirector.GoToGroupsMembers(_webContext.GroupID);
        }

        private bool ViewerIsMember()
        {
            bool result = false;
            if (_webContext.CurrentUser != null)
            {
                if (_groupService.IsOwner(_webContext.CurrentUser.AccountID, _webContext.GroupID))
                    result = true;
                else if (_groupService.IsMember(_webContext.CurrentUser.AccountID, _webContext.GroupID))
                    result = true;
            }
            return result;
        }
    }
    
}