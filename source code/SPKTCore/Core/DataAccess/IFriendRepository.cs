using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using StructureMap;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    //[PluginFamily("Default")]
    public interface IFriendRepository
    {
        Friend GetFriendByID(Int32 FriendID);
        List<Friend> GetFriendsByAccountID(Int32 AccountID);
        List<Account> GetFriendsAccountsByAccountID(Int32 AccountID);
        void SaveFriend(Friend friend);
        void DeleteFriend(Friend friend);
        void DeleteFriendByID(Int32 AccountIDToRemoveFriendFrom, Int32 FriendIDToRemove);
        List<Account> GetFriendMutaul(Account account);
        void GetFriend(Account account);
        Friend getfm(Friend fs);
        Friend getfm1(Friend fs);
        Friend getfm2(Friend fs);
        Friend getfm3(Friend fs);
        //void saveMutual(FriendMutual fm);
    }
}
