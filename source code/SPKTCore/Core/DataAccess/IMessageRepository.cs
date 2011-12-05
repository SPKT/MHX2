using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface IMessageRepository
    {
        List<MessageWithRecipient> GetMessagesByAccountID(Int32 AccountID, Int32 PageNumber, MessageFolders Folder);
        MessageWithRecipient GetMessageByMessageID(Int32 MessageID, Int32 RecipientAccountID);
        Int32 SaveMessage(Message message);
        int GetPageCount(MessageFolders messageFolder, Int32 RecipientAccountID);
        void DeleteMessage(Message message);
        Message GetMessageByID(int MessageID);
    }
}
