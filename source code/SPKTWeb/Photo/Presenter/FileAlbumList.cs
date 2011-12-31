using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using SPKTWeb.Photo.Interface;
using SPKTCore.Core.Impl;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess.Impl;

namespace SPKTWeb.Photo.Presenter
{
    public class FileAlbumList
    {
        private IProfileRepository _profileRepository;
        private IUserSession _userSession;
        private IAccountRepository _accountRepository;
        private IWebContext _webContext;

        private Int32 accountID;
        private Account account;
        Folder folder;
        private List<File> file;
        FileRepository _fr;
        IFileAlbumList _view;
        IFolderRepository _for;
        public FileAlbumList()
        {
            _fr = new FileRepository();
            _userSession = new UserSession();
            _accountRepository = new AccountRepository();
            _webContext = new WebContext();
            _for = new FolderRepository();
        }
        public void Init(IFileAlbumList view)
        {
            if (_userSession.LoggedIn)
            {
                _view = view;
                LoadFile();
            }
        }
        public void LoadFile()
        {
           // folder = _for.GetFolderByID(_webContext.FolderID);
            if (_webContext.FolderID > 1)
            {
                _view.LoadFile(_fr.GetFilesByFolderID1(_webContext.FolderID));
            }
        }
        public void LoadFileMain()
        {
            if (_webContext.FolderID > 1)
            {
                //_view.LoadFileMain(_fr.GetFilesByFolderID1(_webContext.FolderID)[0]);
            }
        }
        public void LoadCountFile()
        {
            if (_webContext.FolderID > 1)
            {
                //_view.LoadCountFile(_fr.GetFilesByFolderID1(_webContext.FolderID).Count);
            }
        }
    }
}