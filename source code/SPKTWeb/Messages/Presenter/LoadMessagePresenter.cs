using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Domain;
using SPKTCore.Core;
using SPKTCore.Core.Impl;
using SPKTWeb.Messages.Interface;
using SPKTCore.Core.DataAccess.Impl;

namespace SPKTWeb.Messages.Presenter
{
    public class LoadMessagePresenter
    {
        private ILoadMessage _view;
        private IMessageRepository _messageRepository;
        private IMessageRecipientRepository _messageRecipientRepository;
        private IUserSession _userSession;
        private IWebContext _webContext;
        private IAccountRepository _ac;
        public LoadMessagePresenter()
        {
            _messageRepository = new MessageRepository();
            _messageRecipientRepository = new MessageRecipientRepository();
            _userSession = new UserSession();
            _webContext = new WebContext();
            _ac = new AccountRepository();
        }
        public void Init(ILoadMessage view,bool Ispoback)
        {
            _view = view;
            if (_userSession.CurrentUser != null)
            {
                    _view.LoadMessages(_messageRepository.GetMessagesByAccountID(_userSession.CurrentUser.AccountID,
                                                                                 _webContext.PageNumber,
                                                                                 (MessageFolders)_webContext.FolderID));
               
            }
        }


    }
}