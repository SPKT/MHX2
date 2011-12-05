using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Friends.Interface
{
    public interface IShowFriend
    {
        void LoadFriend(List<Account> Accounts);
    }
}