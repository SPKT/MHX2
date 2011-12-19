using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using StructureMap;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    //[PluginFamily("Default")]
    public interface IFriendInvitationRepository
    {
        List<FriendInvitation> GetFriendInvitationsByAccountID(Int32 AccountID);
        void SaveFriendInvitation(FriendInvitation friendInvitation);
        FriendInvitation GetFriendInvitationByGUID(Guid guid);
        void CleanUpFriendInvitationsForThisEmail(FriendInvitation friendInvitation);
        List<Account> FriendInv(Account account);
        Guid GUID(Account account, Account acInvite);
    }
}
