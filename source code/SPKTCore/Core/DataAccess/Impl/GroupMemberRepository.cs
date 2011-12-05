using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess.Impl
{
    public class GroupMemberRepository : IGroupMemberRepository
    {
        private Connection conn;
        public GroupMemberRepository()
        {
            conn = new Connection();
        }

        public List<int> GetMemberAccountIDsByGroupID(Int32 GroupID)
        {
            List<int> result = new List<int>();
            using (SPKTDataContext dc = conn.GetContext())
            {
                result = dc.GroupMembers.Where(gm => gm.IsApproved && gm.GroupID == GroupID).Select(gm => gm.AccountID).ToList();
                result.Add(dc.Groups.Where(g => g.GroupID == GroupID).Select(gm => gm.AccountID).FirstOrDefault());
            }
            return result;
        }

        public bool IsMember(Int32 AccountID, Int32 GroupID)
        {
            bool result = false;
            using (SPKTDataContext dc = conn.GetContext())
            {
                if (dc.GroupMembers.Where(gm => gm.AccountID == AccountID && gm.GroupID == GroupID && gm.IsApproved).FirstOrDefault() != null)
                    result = true;
            }
            return result;
        }

        public bool IsAdministrator(Int32 AccountID, Int32 GroupID)
        {
            bool result = false;
            using (SPKTDataContext dc = conn.GetContext())
            {
                if (dc.GroupMembers.Where(gm => gm.AccountID == AccountID &&
                    gm.GroupID == GroupID &&
                    gm.IsAdmin &&
                    gm.IsApproved).FirstOrDefault() != null)
                    result = true;
            }
            return result;
        }

        public void DeleteGroupMembers(List<int> MembersToDelete, int GroupID)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<GroupMember> members =
                    dc.GroupMembers.Where(gm => MembersToDelete.Contains(gm.AccountID) && gm.GroupID == GroupID);
                dc.GroupMembers.DeleteAllOnSubmit(members);
                dc.SubmitChanges();
            }
        }

        public void ApproveGroupMembers(List<int> MembersToApprove, int GroupID)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<GroupMember> members =
                    dc.GroupMembers.Where(gm => MembersToApprove.Contains(gm.AccountID) && gm.GroupID == GroupID);
                foreach (GroupMember member in members)
                {
                    member.IsApproved = true;
                }
                dc.SubmitChanges();
            }
        }

        public void PromoteGroupMembersToAdmin(List<int> MembersToPromote, int GroupID)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<GroupMember> members =
                    dc.GroupMembers.Where(gm => MembersToPromote.Contains(gm.AccountID) && gm.GroupID == GroupID);
                foreach (GroupMember member in members)
                {
                    member.IsAdmin = true;
                }
                dc.SubmitChanges();
            }
        }

        public void DemoteGroupMembersFromAdmin(List<int> MembersToDemote, int GroupID)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<GroupMember> members =
                    dc.GroupMembers.Where(gm => MembersToDemote.Contains(gm.AccountID) && gm.GroupID == GroupID);
                foreach (GroupMember member in members)
                {
                    member.IsAdmin = false;
                }
                dc.SubmitChanges();
            }
        }

        public void SaveGroupMember(GroupMember groupMember)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                if (dc.GroupMembers.Where(gm => gm.GroupID == groupMember.GroupID && gm.AccountID == groupMember.AccountID).FirstOrDefault() == null)
                {
                    dc.GroupMembers.InsertOnSubmit(groupMember);
                    Group group = dc.Groups.Where(g => g.GroupID == groupMember.GroupID).FirstOrDefault();
                    group.MemberCount++;
                    dc.SubmitChanges();
                }
            }
        }

        public void DeleteAllGroupMembersForGroup(int GroupID)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                dc.GroupMembers.DeleteAllOnSubmit(dc.GroupMembers.Where(gm => gm.GroupID == GroupID));
                dc.SubmitChanges();
            }
        }

        public void DeleteGroupMember(GroupMember groupMember)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                dc.GroupMembers.Attach(groupMember, true);
                dc.GroupMembers.DeleteOnSubmit(groupMember);
                dc.SubmitChanges();
            }
        }

    }
}
