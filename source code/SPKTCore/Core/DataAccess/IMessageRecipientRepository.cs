using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface IMessageRecipientRepository
    {
        List<MessageRecipient> GetMessageRecipientsByMessageID(Int32 MessageID);
        MessageRecipient GetMessageRecipientByID(Int32 MessageRecipientID);
        void SaveMessageRecipient(MessageRecipient messageRecipient);
        void DeleteMessageRecipient(MessageRecipient messageRecipient);
    }
}
