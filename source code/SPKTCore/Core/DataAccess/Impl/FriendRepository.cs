using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using StructureMap;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.DataAccess;

namespace SPKTCore.Core.DataAccess.Impl
{
    //[Pluggable("Default")]
    public class FriendRepository : IFriendRepository
    {
        private Connection conn;
        public FriendRepository()
        {
            conn = new Connection();
        }

        public Friend GetFriendByID(Int32 FriendID)
        {
            Friend result;

            using (SPKTDataContext dc = conn.GetContext())
            {
                result = dc.Friends.Where(f => f.FriendID == FriendID).FirstOrDefault();
            }

            return result;
        }

        public List<Friend> GetFriendsByAccountID(Int32 AccountID)
        {
            List<Friend> result = new List<Friend>();
            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<Friend> friends = (from f in dc.Friends
                                               where f.AccountID == AccountID &&
                                               f.MyFriendAccountID != AccountID
                                               select f).Distinct();
                result = friends.ToList();

                var friends2 = (from f in dc.Friends
                                where f.MyFriendAccountID == AccountID &&
                                f.AccountID != AccountID
                                select new
                                {
                                    FriendID = f.FriendID,
                                    AccountID = f.MyFriendAccountID,
                                    MyFriendAccountID = f.AccountID,
                                    CreateDate = f.CreateDate,
                                    Timestamp = f.Timestamp
                                }).Distinct();

                foreach (object o in friends2)
                {
                    Friend friend = o as Friend;
                    if (friend != null)
                        result.Add(friend);
                }
            }
            return result;
        }

        public List<Account> GetFriendsAccountsByAccountID(Int32 AccountID)
        {
            List<Friend> friends = GetFriendsByAccountID(AccountID);
            List<int> accountIDs = new List<int>();
            foreach (Friend friend in friends)
            {
                accountIDs.Add(friend.MyFriendAccountID);
            }

            List<Account> result = new List<Account>();
            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<Account> accounts = from a in dc.Accounts
                                                where accountIDs.Contains(a.AccountID)
                                                select a;
                result = accounts.ToList();
            }
            return result;
        }

        public void SaveFriend(Friend friend)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                if (friend.FriendID > 0)
                {
                    dc.Friends.Attach(friend, true);
                }
                else
                {
                    friend.CreateDate = DateTime.Now;
                    dc.Friends.InsertOnSubmit(friend);
                }
                dc.SubmitChanges();
            }
        }

        public void DeleteFriend(Friend friend)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                dc.Friends.Attach(friend, true);
                dc.Friends.DeleteOnSubmit(friend);
                dc.SubmitChanges();
            }
        }

        public void DeleteFriendByID(Int32 AccountIDToRemoveFriendFrom, Int32 FriendIDToRemove)
        {
            List<Friend> workingList = new List<Friend>();
            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<Friend> friends = from f in dc.Friends
                                              where (f.AccountID == AccountIDToRemoveFriendFrom &&
                                              f.MyFriendAccountID == FriendIDToRemove) ||
                                              (f.AccountID == FriendIDToRemove &&
                                              f.MyFriendAccountID == AccountIDToRemoveFriendFrom)
                                              select f;

                workingList = friends.ToList();
            }

            foreach (Friend friend in workingList)
            {
                DeleteFriend(friend);
            }
        }
        public List<Account> GetFriendMutaul(Account account)
        {
            return GetFriendsAccountsByAccountID(account.AccountID);
        }
        public void GetFriend(Account account)
        {
           // List<Account> Acfriend = new List<Account>();
            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<Friend> fi = from f in dc.Friends where f.MyFriendAccountID == account.AccountID || f.AccountID == account.AccountID select f;
                fi.ToList();
                foreach (Friend i in fi)
                {
                    FriendMutual mf = new FriendMutual();
                    if (i.AccountID == account.AccountID)
                    {
                        mf.AccountID = i.AccountID;
                        mf.AcMyFriendID = i.MyFriendAccountID;
                        mf.AcMutual = 0;
                    }
                    if (i.MyFriendAccountID == account.AccountID)
                    {
                        mf.AccountID = i.MyFriendAccountID;
                        mf.AcMyFriendID = i.AccountID;
                        mf.AcMutual = 0;
                    }
                    saveMutual(mf);
                }
            }
        }
        public void GetF()
        {
            
        }
        public Friend getfm(Friend fs)
        {
            Friend you=new Friend();
            using (SPKTDataContext dc = conn.GetContext())
            {
                you = dc.Friends.Where(f => f.MyFriendAccountID == fs.AccountID).FirstOrDefault();
            }
            return you;
        }
        public Friend getfm1(Friend fs)
        {
            Friend you = new Friend();
            using (SPKTDataContext dc = conn.GetContext())
            {
                you = dc.Friends.Where(f => f.AccountID == fs.MyFriendAccountID).FirstOrDefault();
            }
            return you;
        }
        public Friend getfm2(Friend fs)
        {
            Friend you = new Friend();
            using (SPKTDataContext dc = conn.GetContext())
            {
                you = dc.Friends.Where(f => f.MyFriendAccountID == fs.MyFriendAccountID).FirstOrDefault();
            }
            return you;
        }
        public Friend getfm3(Friend fs)
        {
            Friend you = new Friend();
            using (SPKTDataContext dc = conn.GetContext())
            {
                you = dc.Friends.Where(f => f.AccountID == fs.AccountID).FirstOrDefault();
            }
            return you;
        }
        public void saveMutual(FriendMutual fm)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                if (fm.FriendMutualID > 0)
                {
                    dc.FriendMutuals.Attach(fm, true);
                }
                else
                {
                    
                    dc.FriendMutuals.InsertOnSubmit(fm);
                }
                dc.SubmitChanges();
            }
        }
    }
}
