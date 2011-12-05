using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPKTCore.Core.Domain
{
    
    public partial class MessageType
    {
        public enum MessageTypes
        {
            FriendRequest = 1,
            FriendConfirm = 2,
            Message = 3
        }
    }
}
