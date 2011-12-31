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
    public class Share
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
        AccountFileShareRepository _af;
        IAccountFolderShareRepository _ac;
        public Share()
        {
            _af = new AccountFileShareRepository();
            _ac = new AccountFolderShareRepository();
        }
        public void Shared(Account ac, Account acby, File file)
        {
            AccountFileShare asf = new AccountFileShare();
            asf.AccountByID = acby.AccountID;
            asf.AccountID = ac.AccountID;
            asf.FileID = file.FileID;
            _af.Save(asf);
        }
        public void Shared1(Account ac, Account acby, Folder file)
        {
            AccountFolderShare asf = new AccountFolderShare();
            asf.AccountByID = acby.AccountID;
            asf.AccountID = ac.AccountID;
            asf.FolderID = file.FolderID;
            _ac.Save(asf);
        }
    }
}