using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core
{
    public interface IGroupService
    {
        int SaveGroup(Group group);
        bool IsOwnerOrAdministrator(Int32 AccountID, Int32 GroupID);
        bool IsOwner(Int32 AccountID, Int32 GroupID);
        bool IsAdministrator(Int32 AccountID, Int32 GroupID);
        bool IsMember(Int32 AccountID, Int32 GroupID);
    }
}
