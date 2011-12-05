using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface IGroupToGroupTypeRepository
    {
        void SaveGroupToGroupType(GroupToGroupType groupToGroupType);
        void DeleteGroupToGroupType(GroupToGroupType groupToGroupType);
        void SaveGroupTypesForGroup(List<long> SelectedGroupTypeIDs, int GroupID);
    }
}
