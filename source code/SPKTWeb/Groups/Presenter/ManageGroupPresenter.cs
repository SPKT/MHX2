using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTWeb.Groups.Interface;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Impl;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Groups.Presenter
{
    public class ManageGroupPresenter
    {
        private IManageGroup _view;
        private IRedirector _redirector;
        private IWebContext _webContext;
        private IGroupRepository _groupRepository;
        private IGroupService _groupService;
        private IFileService _fileService;
        private IBoardForumRepository _forumRepository;
        private IFileRepository _fileRepository;
        private IGroupToGroupTypeRepository _groupToGroupTypeRepository;
        private IGroupTypeRepository _groupTypeRepository;

        public ManageGroupPresenter()
        {
            _redirector = new Redirector();
            _webContext = new WebContext();
            _groupRepository = new GroupRepository();
            _groupService = new GroupService();
            _fileService = new FileService();
            _forumRepository = new BoardForumRepository();
            _fileRepository = new FileRepository();
            _groupToGroupTypeRepository = new GroupToGroupTypeRepository();
            _groupTypeRepository = new GroupTypeRepository();
        }

        public void Init(IManageGroup view, bool IsPostBack)
        {
            _view = view;
            
            bool IsLogin=_webContext.LoggedIn;
            //TODO: _webContext.CurrentUser.AccountID có thể bị Null Reference?
            if (IsLogin == false)
                _redirector.GoToAccountLoginPage();
            if (_webContext.GroupID > 0 && !_groupService.IsOwnerOrAdministrator(_webContext.CurrentUser.AccountID, _webContext.GroupID))
                _redirector.GoToAccountAccessDenied();

            if (!IsPostBack)
                view.LoadGroupTypes(_groupTypeRepository.GetAllGroupTypes());

            if (_webContext.GroupID > 0 && !IsPostBack)
                _view.LoadGroup(_groupRepository.GetGroupByID(_webContext.GroupID), _groupTypeRepository.GetGroupTypesByGroupID(_webContext.GroupID));
        }

        public void SaveGroup(Group group, HttpPostedFile file, List<long> selectedGroupTypeIDs)
        {
            if (group.Description.Length > 2000)
            {
                _view.ShowMessage("Mô tả của bạn về " + group.Description.Length.ToString() +
                                  " dài quá 2000 ký tứ!");
            }
            else
            {
                group.AccountID = _webContext.CurrentUser.AccountID;
                group.PageName = group.PageName.Replace(" ", "-");
                if (group.GroupID == 0 && _groupRepository.CheckIfGroupPageNameExists(group.PageName))
                {
                    _view.ShowMessage("The page name you specified is already in use!");
                }
                else
                {
                    if (file.ContentLength > 0)
                    {
                        List<Int64> fileIDs = _fileService.UploadPhotos(1, _webContext.CurrentUser.AccountID,
                                                                        _webContext.Files, 2);
                        //should only be one item uploaded!
                        if (fileIDs.Count == 1)
                            group.FileID = fileIDs[0];
                    }
                    group.GroupID = _groupService.SaveGroup(group);
                    _groupToGroupTypeRepository.SaveGroupTypesForGroup(selectedGroupTypeIDs, group.GroupID);
                    _redirector.GoToGroupsViewGroup(group.PageName);
                }
            }
        }

        public string GetImagePathByID(Int64 ImageID)
        {
            return _fileService.GetFullFilePathByFileID(ImageID, File.Sizes.S);
        }
    }
}