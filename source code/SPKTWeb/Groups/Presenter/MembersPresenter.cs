using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTWeb.Groups.Interface;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Impl;

namespace SPKTWeb.Groups.Presenter
{
    public class MembersPresenter
    {
        private IMembers _view;
        private IAccountRepository _accountRepository;
        private IGroupMemberRepository _groupMemberRepository;
        private IGroupService _groupService;
        private IWebContext _webContext;
        private IRedirector _redirector;
        public MembersPresenter()
        {
            _accountRepository = new AccountRepository();
            _groupMemberRepository = new GroupMemberRepository();
            _webContext = new WebContext();
            _redirector = new Redirector();
            _groupService = new GroupService();
        }

        public void Init(IMembers view, bool IsPostBack)
        {
            _view = view;

            //do we show the buttons?
            if (_webContext.CurrentUser == null)
                _view.SetButtonsVisibility(false);
            else if (_groupService.IsOwnerOrAdministrator(_webContext.CurrentUser.AccountID, _webContext.GroupID))
                _view.SetButtonsVisibility(true);
            else
                _view.SetButtonsVisibility(false);

            if (!IsPostBack)
                LoadData();
        }

        public void Next()
        {
            _redirector.GoToGroupsMembers(_webContext.GroupID, (_webContext.PageNumber + 1));
        }

        public void Previous()
        {
            _redirector.GoToGroupsMembers(_webContext.GroupID, (_webContext.PageNumber - 1));
        }

        public void LoadData()
        {
            _view.LoadData(_accountRepository.GetApprovedAccountsByGroupID(_webContext.GroupID, _webContext.PageNumber),
                           _accountRepository.GetAccountsToApproveByGroupID(_webContext.GroupID));
        }

        public void ApproveMembers(List<int> MemberIDs)
        {
            _groupMemberRepository.ApproveGroupMembers(MemberIDs, _webContext.GroupID);
            LoadData();
            _view.ShowMessage("Đã chấp nhận thành công!");
        }

        public void DeleteMembers(List<int> MemberIDs)
        {
            _groupMemberRepository.DeleteGroupMembers(MemberIDs, _webContext.GroupID);
            LoadData();
            _view.ShowMessage("Đã xóa thành viên thành công!");
        }

        public void PromoteMembers(List<int> MemberIDs)
        {
            _groupMemberRepository.PromoteGroupMembersToAdmin(MemberIDs, _webContext.GroupID);
            LoadData();
            _view.ShowMessage("Thêm Admin thành công");
        }

        public void DemoteMembers(List<int> MemberIDs)
        {
            _groupMemberRepository.DemoteGroupMembersFromAdmin(MemberIDs, _webContext.GroupID);
            LoadData();
            _view.ShowMessage("Xóa Admin thành công!");
        }

        public void Back()
        {
            _redirector.GoToGroupsViewGroup(_webContext.GroupID);
        }
    }
}