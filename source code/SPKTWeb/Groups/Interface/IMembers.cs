using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Groups.Interface
{
    public interface IMembers
    {
        void LoadData(List<Account> Members, List<Account> MembersToApprove);
        void ShowMessage(string Message);
        void SetButtonsVisibility(bool Visible);
    }
}