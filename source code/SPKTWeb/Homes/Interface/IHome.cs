using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Homes.Interface
{
    public interface IHome
    {
        void DisplayCurrentAccount(Account account);
        void LoadStatus(List<StatusUpdate> listStatus);
        void LoadStatusControl(List<VisibilityLevel> ListVisibilityLevel, bool IsUser);

    }
}