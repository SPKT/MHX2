using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess;
using StructureMap;

namespace SPKTCore.Core.Impl
{
    [Pluggable("Default")]
    public class FriendService : IFriendService
    {
        private IFriendInvitationRepository _friendInvitationRepository;
        private IFriendRepository _friendRepository;
        private IAccountRepository _accountRepository;
        private IWebContext _webContext;
        private IUserSession _userSession;
        SPKTDataContext dc;
        public FriendService()
        {
            dc= new SPKTDataContext();
            _accountRepository = new SPKTCore.Core.DataAccess.Impl.AccountRepository();
            _webContext = new SPKTCore.Core.Impl.WebContext();
            _friendInvitationRepository = new SPKTCore.Core.DataAccess.Impl.FriendInvitationRepository();
            _friendRepository = new SPKTCore.Core.DataAccess.Impl.FriendRepository();
            _userSession = new SPKTCore.Core.Impl.UserSession();
           
        }
        public bool IsFriend(Account account, Account accountBeingViewed)
        {
            if (account == null)
                return false;

            if (accountBeingViewed == null)
                return false;

            if (account.AccountID == accountBeingViewed.AccountID && account.AccountID!=_userSession.CurrentUser.AccountID)
                return true;
            else
            {
                Friend friend = _friendRepository.GetFriendsByAccountID(accountBeingViewed.AccountID).Where(f => f.MyFriendAccountID == account.AccountID).FirstOrDefault();
                if (friend != null)
                    return true;
            }
            return false;
        }
        public void CreateFriendFromFriendInvitation(Guid InvitationKey, Account InvitationTo)
        {
            FriendInvitation friendInvitation = _friendInvitationRepository.GetFriendInvitationByGUID(InvitationKey);
            friendInvitation.BecameAccoutnID= InvitationTo.AccountID;
            _friendInvitationRepository.SaveFriendInvitation(friendInvitation);
            _friendInvitationRepository.CleanUpFriendInvitationsForThisEmail(friendInvitation);

            Friend friend = new Friend();
            friend.AccountID = friendInvitation.AccountID;
            friend.MyFriendAccountID = InvitationTo.AccountID;
            _friendRepository.SaveFriend(friend);

            //_friendRepository.GetFriend(InvitationTo);
        }
        public void CreateFriendMutualFromFriend()
        {
        }
        public void DeleteFriendFromFriendInvitation(Guid InvitationKey, Account InvitationTo)
        {
            FriendInvitation friendInvitation = _friendInvitationRepository.GetFriendInvitationByGUID(InvitationKey);
            friendInvitation.BecameAccoutnID = -1;
            _friendInvitationRepository.SaveFriendInvitation(friendInvitation);
            _friendInvitationRepository.CleanUpFriendInvitationsForThisEmail(friendInvitation);
        }
        public int CountFriend(Account account)
        {
            List<Friend> l=_friendRepository.GetFriendsByAccountID(account.AccountID);
            int dem = l.Count();
            return dem;
        }
       public List<Account> SearchFriend(Account account)
        {
          
            List<Account> list = new List<Account>();
            foreach (Account a in dc.Accounts)
            {
                if (IsFriend(a, account) == true || IsFriend(account, a) == true)
                    list.Add(a);
                if (a.AccountID == account.AccountID)
                    list.Remove(a);
            }
            return list;
        }
       public List<Account> FriendInv(Account account)
       {
           //SPKTDataContext dc = new SPKTDataContext();
           List<Account> list = new List<Account>();
           //List<FriendInvitation> list1 = new List<FriendInvitation>();
           foreach (FriendInvitation i in dc.FriendInvitations)
           {
               if(i.AccountID==account.AccountID && i.BecameAccoutnID==0)
                   list.Add(_accountRepository.GetAccountByEmail(i.Email));
           }
           
           return list;
          
       }
        //moi
       public int CountFiendMutual(Account account, Account accountview)
       {
           int dem=0;
           foreach (Account a in SearchFriend(account))
           {
               foreach (Account ac in SearchFriend(accountview))
               {
                   if (a.AccountID == ac.AccountID)
                       dem++;
               }
           }
           return dem;
       }
       public List<Account> FriendMutual(Account account)
       {
           List<Account> list = new List<Account>();
           foreach (Account a in SearchFriend(account))
           {
               foreach (Account ac in SearchFriend(a))
               {
                   if (IsFriend(account, ac) == false && IsFriend(ac, account) == false)
                       list.Add(ac);
                   if (account.AccountID == ac.AccountID)
                       list.Remove(ac);
               }
           }
           return list;
       }
       public List<Account> GetListFriendByAccount(int AccountID)
       {
           return _friendRepository.GetFriendsAccountsByAccountID(AccountID);
       }
    }
}
