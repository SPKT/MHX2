using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface IGroupTypeRepository
    {
        GroupType GetGroupTypeByID(Int32 GroupTypeID);
        List<GroupType> GetGroupTypesByGroupID(Int32 GroupID);
        Int64 SaveGroupType(GroupType groupType);
        void DeleteGroupType(GroupType groupType);
        List<GroupType> GetAllGroupTypes();
    }
}
