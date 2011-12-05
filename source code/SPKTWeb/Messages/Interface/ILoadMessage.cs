using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Messages.Interface
{
    public interface ILoadMessage
    {
        void LoadMessages(List<MessageWithRecipient> Messages);
        void LoadUsernameFromMessage(string Email);
    }
}