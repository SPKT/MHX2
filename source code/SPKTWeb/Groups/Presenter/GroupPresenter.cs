using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTWeb.Groups.Interface;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Impl;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Groups.Presenter
{
    public class GroupPresenter
    {
        private IGroup _view;
        private IRedirector _redirector;
        private IWebContext _webContext;
        private IGroupRepository _groupRepository;
        private IFileService _fileService;

        public GroupPresenter()
        {
            _redirector = new Redirector();
            _webContext = new WebContext();
            _groupRepository = new GroupRepository();
            _fileService = new FileService();
        }

        public void Init(IGroup view)
        {
            _view = view;
            _view.LoadData(_groupRepository.GetLatestGroups());
        }

        public string GetImageByID(Int64 ImageID, File.Sizes Size)
        {
            return _fileService.GetFullFilePathByFileID(ImageID, Size);
        }

        public void GoToGroup(string GroupPageName)
        {
            _redirector.GoToGroupsViewGroup(GroupPageName);
        }
    }
    
}