using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess.Impl
{
    [Pluggable("Default")]
    public class FriendInvitationRepository : IFriendInvitationRepository
    {
        private Connection conn;
        //moi
        private AccountRepository _accountRepository;
        private Guid _guid;
        public FriendInvitationRepository()
        {
            conn = new Connection();
        }

        public List<FriendInvitation> GetFriendInvitationsByAccountID(Int32 AccountID)
        {
            List<FriendInvitation> result = new List<FriendInvitation>();
            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<FriendInvitation> friendInvitations = dc.FriendInvitations.Where(fi => fi.AccountID == AccountID);
                result = friendInvitations.ToList();
            }
            return result;
        }

        public FriendInvitation GetFriendInvitationByGUID(Guid guid)
        {
            FriendInvitation friendInvitation;
            using (SPKTDataContext dc = conn.GetContext())
            {
                friendInvitation = dc.FriendInvitations.Where(fi => fi.GUID == guid).FirstOrDefault();
            }
            return friendInvitation;
        }
        public void SaveFriendInvitation(FriendInvitation friendInvitation)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                if (friendInvitation.FriendInvitationID> 0)
                {
                    dc.FriendInvitations.Attach(friendInvitation, true);
                }
                else
                {
                    friendInvitation.CreateDate = DateTime.Now;
                    dc.FriendInvitations.InsertOnSubmit(friendInvitation);
                }
                dc.SubmitChanges();
            }
        }
        public void CleanUpFriendInvitationsForThisEmail(FriendInvitation friendInvitation)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<FriendInvitation> friendInvitations = from fi in dc.FriendInvitations
                                                                  where fi.Email == friendInvitation.Email &&
                                                                    fi.BecameAccoutnID == 0 &&
                                                                    fi.AccountID == friendInvitation.AccountID
                                                                  select fi;
                foreach (FriendInvitation invitation in friendInvitations)
                {
                    dc.FriendInvitations.DeleteOnSubmit(invitation);
                }
                dc.SubmitChanges();
            }
        }
        //moi
        public List<Account> FriendInv(Account account)
        {
            _accountRepository = new AccountRepository();
            List<Account> list = new List<Account>();
            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<Account> ac = (from a in dc.FriendInvitations
                                           join b in dc.Accounts on a.AccountID equals b.AccountID
                                           where (a.Email == account.Email && a.BecameAccoutnID == 0)
                                           select _accountRepository.GetAccountByID(a.AccountID)).Distinct();
                list = ac.ToList();
            }
            
            return list;
        }
        public Guid GUID(Account account, Account acInvite)
        {
            
            using (SPKTDataContext dc = conn.GetContext())
            {
                _guid = (from a in dc.FriendInvitations
                         where (a.AccountID == acInvite.AccountID && a.Email == account.Email)
                         select a.GUID).FirstOrDefault();
            }
            return _guid;
        }
    }
}
