using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPKTCore.Core
{
    public interface IMessageService
    {
        void SendMessage(string Body, string Subject, string[] To);
        void saveMessageRecipient(int messageID);
    }
}
