using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Messages.Interface
{
    public interface INewMessage
    {
        void LoadReply(MessageWithRecipient message);
        void LoadTo(string Username);
        void LoadSubject(string Subject);
        void LoadContent(string Content);
    }
}