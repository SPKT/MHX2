using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Groups.Interface
{
    public interface IManageGroup
    {
        void LoadGroup(Group group, List<GroupType> selectedTypes);
        void ShowMessage(string Message);
        void LoadGroupTypes(List<GroupType> types);

    }
}