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
    public class BriefMessage
    {
        
        private IMessageRepository _messageRepository;
        private IMessageRecipientRepository _messageRecipientRepository;
        private IUserSession _userSession;
        private IWebContext _webContext;
        private IAccountRepository _ac;
        public BriefMessage()
        {
            _messageRepository = new MessageRepository();
            _messageRecipientRepository = new MessageRecipientRepository();
            _userSession = new UserSession();
            _webContext = new WebContext();
            _ac = new AccountRepository();
        }
        public void savebriefmess(int id)
        {
            MessageRecipient ms;
            ms = _messageRecipientRepository.GetMessageRecipientByID(id);
            ms.MessageStatusTypeID = 2;
            _messageRecipientRepository.SaveMessageRecipient(ms);
        }
    }
}