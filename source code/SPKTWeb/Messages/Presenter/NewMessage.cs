using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Impl;
using SPKTWeb.Messages.Interface;

namespace SPKTWeb.Messages.Presenter
{
    public class NewMessage
    {
        private INewMessage _view;
        private IWebContext _webContext;
        private IMessageService _messageService;
        private IMessageRepository _messageRepository;
        private IUserSession _userSession;
        private IAccountRepository _accountRepository;
        public NewMessage()
        {
            _webContext = new WebContext();
            _userSession = new UserSession();
            _messageService = new MessageService();
            _messageRepository = new SPKTCore.Core.DataAccess.Impl.MessageRepository();
            _accountRepository = new SPKTCore.Core.DataAccess.Impl.AccountRepository();
        }
        public void Init(INewMessage view)
        {
            _view = view;
            if (_webContext.MessageID != 0)
                _view.LoadReply(_messageRepository.GetMessageByMessageID(_webContext.MessageID, _userSession.CurrentUser.AccountID));
            if (_webContext.AccountID != 0)
                _view.LoadTo(_accountRepository.GetAccountByID(_webContext.AccountID).UserName);
        }

        public void SendMessage(string Subject, string Message, string[] To)
        {
            _messageService.SendMessage(Message, Subject, To);
        }
    }
}