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
    public class ReadMessagePresenter
    {
        private IReadMessage _view;
        private IWebContext _webContext;
        private IMessageRepository _messageRepository;
        private IUserSession _userSession;
        private IRedirector _redirector;
       
        public ReadMessagePresenter()
        {
            _webContext = new WebContext();
            _userSession = new UserSession();
            _redirector = new Redirector();
            _messageRepository = new SPKTCore.Core.DataAccess.Impl.MessageRepository();
           
        }
        public void Init(IReadMessage view)
        {
            _view = view;
            _view.LoadMessage(_messageRepository.GetMessageByMessageID(_webContext.MessageID, _userSession.CurrentUser.AccountID));
        }

        public void Reply()
        {
            //_redirector.GoToMailNewMessage(_webContext.MessageID);
        }
    }
}