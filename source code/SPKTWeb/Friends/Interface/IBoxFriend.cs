using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Friends.Interface
{
    public interface IBoxFriend
    {
        void load_InvtFriend(List<Account> invite);
        bool ShowPanel { set; }
        
    }
}