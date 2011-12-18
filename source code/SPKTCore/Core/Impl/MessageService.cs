using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.Impl
{
    public class MessageService : IMessageService
    {
        private IUserSession _userSession;
        private IMessageRepository _messageRepository;
        private IMessageRecipientRepository _messageRecipientRepository;
        private IAccountRepository _accountRepository;
        private IEmail _email;
        public MessageService()
        {
            _userSession = new SPKTCore.Core.Impl.UserSession();
            _messageRepository = new SPKTCore.Core.DataAccess.Impl.MessageRepository();
            _messageRecipientRepository = new SPKTCore.Core.DataAccess.Impl.MessageRecipientRepository();
            _accountRepository = new SPKTCore.Core.DataAccess.Impl.AccountRepository();
            _email =new SPKTCore.Core.Impl.Email();
        }
        public void saveMessageRecipient(int messageID)
        {
            MessageRecipient m = _messageRecipientRepository.GetMessageRecipientByID(messageID);
            m.MessageStatusTypeID = (int)MessageStatusType.MessageStatusTypes.Read;
            _messageRecipientRepository.SaveMessageRecipient(m);
        }
        public void SendMessage(string Body, string Subject, string[] To)
        {
            Message m = new Message();
            m.Body = Body;
            m.Subject = Subject;
            m.CreateDate = DateTime.Now;
            m.MessageTypeID = (int)MessageType.MessageTypes.Message;
            m.SendByAccountID = _userSession.CurrentUser.AccountID;
            Int32 messageID = _messageRepository.SaveMessage(m);

            //create a copy in the sent items folder for this user
            MessageRecipient sendermr = new MessageRecipient();
            sendermr.AccountID = _userSession.CurrentUser.AccountID;
            sendermr.MessageFolderID = (int)MessageFolders.Sent;
            sendermr.MessageStatusTypeID = (int)MessageStatusType.MessageStatusTypes.Unread;
            sendermr.MessageRecipientTypeID = (int)MessageRecipientTypes.TO;
            sendermr.MessageID = messageID;
            _messageRecipientRepository.SaveMessageRecipient(sendermr);

            //send to people in the To field
            foreach (string s in To)
            {
                Account toAccount = null;
                if (s.Contains("@"))
                    toAccount = _accountRepository.GetAccountByEmail(s);
                else
                    toAccount = _accountRepository.GetAccountByUsername(s);

                if (toAccount != null)
                {
                    MessageRecipient mr = new MessageRecipient();
                    mr.AccountID = toAccount.AccountID;
                    mr.MessageFolderID = (int)MessageFolders.Inbox;
                    mr.MessageID = messageID;
                    mr.MessageRecipientTypeID = (int)MessageRecipientTypes.TO;
                    mr.MessageStatusTypeID = (int)MessageStatusType.MessageStatusTypes.Unread;
                    _messageRecipientRepository.SaveMessageRecipient(mr);
                   _email.SendNewMessageNotification(_userSession.CurrentUser, toAccount.Email);
                }
            }
        }
    }
}
