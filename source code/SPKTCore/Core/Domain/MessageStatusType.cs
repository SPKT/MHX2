using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPKTCore.Core.Domain
{
    

    public partial class MessageStatusType
    {
        public enum MessageStatusTypes
        {
            Unread = 1,
            Read = 2,
            Replied = 3,
            Forwarded = 4,
            Spam = 5,
            Filtered = 6
        }
    }
}
