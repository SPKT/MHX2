using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface IGroupMemberRepository
    {
        List<int> GetMemberAccountIDsByGroupID(Int32 GroupID);
        void SaveGroupMember(GroupMember groupMember);
        void DeleteGroupMember(GroupMember groupMember);
        void DeleteGroupMembers(List<int> MembersToDelete, int GroupID);
        void ApproveGroupMembers(List<int> MembersToApprove, int GroupID);
        void PromoteGroupMembersToAdmin(List<int> MembersToPromote, int GroupID);
        void DemoteGroupMembersFromAdmin(List<int> MembersToDemote, int GroupID);
        bool IsAdministrator(Int32 AccountID, Int32 GroupID);
        void DeleteAllGroupMembersForGroup(int GroupID);
        bool IsMember(Int32 AccountID, Int32 GroupID);
    }
}
