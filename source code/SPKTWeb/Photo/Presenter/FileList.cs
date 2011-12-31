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
    public class FileList
    {
        private IProfileRepository _profileRepository;
        private IUserSession _userSession;
        private IAccountRepository _accountRepository;
        private IWebContext _webContext;

        private Int32 accountID;
        private Account account;
        private List<File> file;
        FileRepository _fr;
        IFileList _view;
        IFileAlbumList _view1;
        IFolderRepository _for;
        Folder folder;
        public FileList()
        {
            _fr = new FileRepository();
            _userSession = new UserSession();
            _accountRepository = new AccountRepository();
            _webContext = new WebContext();
            _for = new FolderRepository();
        }
        public void Init(IFileList view)
        {
            if (_userSession.LoggedIn)
            {
                _view = view;
                LoadFile();
            }
        }
        public void Init1(IFileAlbumList view)
        {
            
                _view1 = view;
                LoadFile1();
            
        }
        public void LoadFile()
        {
            account = _userSession.CurrentUser;
            if (_userSession.CurrentUser != null)
            {
                if (_webContext.AccountID > 0 && _webContext.AccountID != _userSession.CurrentUser.AccountID)
                {
                    _view.LoadFile(_fr.GetFilesByAccountID(_webContext.AccountID));
                }
                else
                    _view.LoadFile(_fr.GetFilesByAccountID(account.AccountID));
            }
            else
                _view.LoadFile(_fr.GetFilesByAccountID(_webContext.AccountID));
            
        }
        public void LoadFile1()
        {
            folder = _for.GetFolderByID(_webContext.FolderID);
            _view.LoadFile(_fr.GetFilesByFolderID(folder.FolderID));
        }
    }
}