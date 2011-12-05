using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess.Impl
{
    public class GroupToGroupTypeRepository : IGroupToGroupTypeRepository
    {
        private Connection conn;
        public GroupToGroupTypeRepository()
        {
            conn = new Connection();
        }

        public void SaveGroupTypesForGroup(List<long> SelectedGroupTypeIDs, int GroupID)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                //get a list of current selections
                List<long> currentTypes =
                    dc.GroupToGroupTypes.Where(gt => gt.GroupID == GroupID).Select(gt => gt.GroupTypeID).ToList();

                //make a list of items to delete
                List<long> itemsToDelete = currentTypes.Where(ct => !SelectedGroupTypeIDs.Contains(ct)).ToList();

                //make a list of items to insert
                List<long> itemsToInsert =
                    SelectedGroupTypeIDs.Where(s => !currentTypes.Contains(s)).ToList();

                //delete grouptogrouptypes
                dc.GroupToGroupTypes.DeleteAllOnSubmit(
                    dc.GroupToGroupTypes.Where(g => itemsToDelete.Contains(g.GroupTypeID) && g.GroupID == GroupID));

                //create the actual objects to insert
                List<GroupToGroupType> typesToInsert = new List<GroupToGroupType>();
                foreach (long l in itemsToInsert)
                {
                    GroupToGroupType g = new GroupToGroupType() { GroupID = GroupID, GroupTypeID = l };
                    typesToInsert.Add(g);
                }

                //do the insert
                if (typesToInsert.Count > 0)
                {
                    dc.GroupToGroupTypes.InsertAllOnSubmit(typesToInsert);
                }
                dc.SubmitChanges();
            }
        }

        public void SaveGroupToGroupType(GroupToGroupType groupToGroupType)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                if (dc.GroupToGroupTypes.Where(gt => gt.GroupID == groupToGroupType.GroupID && gt.GroupTypeID == groupToGroupType.GroupTypeID).FirstOrDefault() == null)
                {
                    dc.GroupToGroupTypes.InsertOnSubmit(groupToGroupType);
                    dc.SubmitChanges();
                }
            }
        }

        public void DeleteGroupToGroupType(GroupToGroupType groupToGroupType)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                dc.GroupToGroupTypes.Attach(groupToGroupType, true);
                dc.GroupToGroupTypes.DeleteOnSubmit(groupToGroupType);
                dc.SubmitChanges();
            }
        }
    }
}
