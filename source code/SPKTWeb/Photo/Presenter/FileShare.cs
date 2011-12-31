using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using SPKTWeb.Photo.Interface;
using SPKTCore.Core.Impl;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess.Impl;


namespace SPKTWeb.Photo.Presenter
{
    public class FileShare
    {
        private IProfileRepository _profileRepository;
        private IUserSession _userSession;
        private IAccountRepository _accountRepository;
        private IWebContext _webContext;

        private Int32 accountID;
        private Account account;
        private List<File> file;
        FileRepository _fr;
        IFileShare _view;
        IFileAlbumList _view1;
        IFolderRepository _for;
        Folder folder;
        AccountFileShareRepository _af;
        public FileShare()
        {
            _fr = new FileRepository();
            _userSession = new UserSession();
            _accountRepository = new AccountRepository();
            _webContext = new WebContext();
            _for = new FolderRepository();
            _af = new AccountFileShareRepository();
        }
        public void Init(IFileShare view)
        {
            if (_userSession.LoggedIn)
            {
                _view = view;
                LoadFile();
            }
        }
        
        public void LoadFile()
        {
            account = _userSession.CurrentUser;
            if (_userSession.CurrentUser != null)
            {
                if (_webContext.AccountID > 0 && _webContext.AccountID != _userSession.CurrentUser.AccountID)
                {
                    _view.LoadFileShare(_af.GetFolderByAccountShared(_webContext.AccountID));
                }
                else
                    _view.LoadFileShare(_af.GetFolderByAccountShared(account.AccountID));
            }
            else
                _view.LoadFileShare(_af.GetFolderByAccountShared(_webContext.AccountID));
            
        }
    }
}