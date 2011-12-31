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
    public class LoadFileAlbum
    {
        private IUserSession _userSession;
        private IAccountRepository _accountRepository;
        private IWebContext _webContext;
        private List<File> file;
        FileRepository _fr;
        ILoadAlbum _view;
        FolderRepository _for;
        public LoadFileAlbum()
        {
            _fr = new FileRepository();
            _userSession = new UserSession();
            _accountRepository = new AccountRepository();
            _webContext = new WebContext();
            _for = new FolderRepository();
        }
        public void Init(ILoadAlbum view)
        {
            if (_userSession.LoggedIn)
            {
                _view = view;
                LoadFolder();
                getcount();
            }
        }
        public void LoadFolder()
        {
            if (_userSession.CurrentUser != null)
            {
                if (_webContext.AccountID > 0 && _webContext.AccountID != _userSession.CurrentUser.AccountID)
                {
                    _view.LoadFolder(_for.GetFoldersByAccountID1(_webContext.AccountID));
                }
                else
                    _view.LoadFolder(_for.GetFoldersByAccountID1(_userSession.CurrentUser.AccountID));
            }
            else
                _view.LoadFolder(_for.GetFoldersByAccountID1(_webContext.AccountID));
        }
        public int count;
        public void setcount(int c)
        {
            count = c;
        }
        public int getcount()
        {
            return _for.GetFoldersByAccountID1(_userSession.CurrentUser.AccountID).Count;
        }
    }
}