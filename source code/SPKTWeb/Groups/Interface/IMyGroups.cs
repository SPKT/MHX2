using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Groups.Interface
{
    public interface IMyGroups
    {
        void LoadData(List<Group> groups);
        void ShowMessage(string message);
    }
}