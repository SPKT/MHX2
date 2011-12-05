using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPKTWeb.Friends.Interface
{
    public interface IConfirmFriendshipRequest
    {
        void LoadDisplay(string FriendInvitationKey, Int32 AccountID, string Username, string SiteName);
        void ShowConfirmPanel(bool value);
        void ShowMessage(string Message);
    }
}