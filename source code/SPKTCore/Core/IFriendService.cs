using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using StructureMap;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core
{
    //[PluginFamily("Default")]
    public interface IFriendService
    {
        void CreateFriendFromFriendInvitation(Guid InvitationKey, Account InvitationTo);
        bool IsFriend(Account account, Account accountBeingViewed);
        int CountFriend(Account account);
        List<Account> GetListFriendByAccount(int AccountID);
        List<Account> FriendMutual(Account account);
        int CountFiendMutual(Account account, Account accountview);
    }
}
