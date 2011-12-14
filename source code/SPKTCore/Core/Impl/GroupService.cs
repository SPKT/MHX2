using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.Impl
{
    public class GroupService : IGroupService
    {
        private IGroupRepository _groupRepository;
        private IGroupMemberRepository _groupMemberRepository;
        private IWebContext _webContext;
        private IBoardForumRepository _forumRepository;
        private IGroupForumRepository _groupForumRepository;
        private IAccountRepository _accountRepository;
        public GroupService()
        {
            _groupRepository = new GroupRepository();
            _webContext =new WebContext();
            _forumRepository =new BoardForumRepository(); 
            _groupForumRepository = new GroupForumRepository();
            _groupMemberRepository =new GroupMemberRepository();
            _accountRepository = new AccountRepository();
        }

        public bool IsOwnerOrAdministrator(Int32 AccountID, Int32 GroupID)
        {
            bool result = false;
            if (IsOwner(AccountID, GroupID) || IsAdministrator(AccountID, GroupID))
                result = true;
            return result;
        }

        public bool IsOwner(Int32 AccountID, Int32 GroupID)
        {
            return _groupRepository.IsOwner(AccountID, GroupID);
        }

        public bool IsAdministrator(Int32 AccountID, Int32 GroupID)
        {
            return _groupMemberRepository.IsAdministrator(AccountID, GroupID);
        }

        public bool IsMember(Int32 AccountID, Int32 GroupID)
        {
            return _groupMemberRepository.IsMember(AccountID, GroupID);
        }

        public int SaveGroup(Group group)
        {
            int result = 0;
            if (group.GroupID > 0)
            {
                result = _groupRepository.SaveGroup(group);
            }
            else
            {
                result = _groupRepository.SaveGroup(group);

                BoardForum forum = new BoardForum();
                forum.CategoryID = 8; //group forums container
                forum.CreateDate = DateTime.Now;
                forum.LastPostByAccountID = _webContext.CurrentUser.AccountID;
                forum.LastPostByUsername = _webContext.CurrentUser.UserName;
                forum.LastPostDate = DateTime.Now;
                forum.Name = group.Name;
                forum.PageName = group.PageName;
                forum.PostCount = 0;
                forum.Subject = group.Name;
                forum.ThreadCount = 0;
                forum.UpdateDate = DateTime.Now;
                int ForumID = _forumRepository.SaveForum(forum);

                //create relationship between the group and forum
                GroupForum gf = new GroupForum();
                gf.ForumID = ForumID;
                gf.GroupID = group.GroupID;
                gf.CreateDate = DateTime.Now;
                _groupForumRepository.SaveGroupForum(gf);
            }

            return result;
        }


        public List<Account> GetAllMemberByGroupID(int GroupID)
        {
            List<Account> accounts = new List<Account>();
            List<int> accountIDs = _groupMemberRepository.GetMemberAccountIDsByGroupID(GroupID);
            foreach (int i in accountIDs)
            {
                accounts.Add(_accountRepository.GetAccountByID(i));
            }
            return accounts;
        }
    }
}
