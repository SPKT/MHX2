using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Interface
{
    public interface IProfileDisplay
    {
        void LoadDisplay(Account account);
        bool ShowFriendRequestButton { set; }
        bool ShowDeleteButton { set; }
    }
}