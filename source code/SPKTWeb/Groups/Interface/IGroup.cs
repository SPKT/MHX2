using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Groups.Interface
{
    public interface IGroup
    {
        void ShowMessage(string message);

        void LoadData(List<Group> list);

    }
}