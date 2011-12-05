using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace SPKTCore.Core
{
    [PluginFamily("Default")]
    public interface IRedirector
    {
        void GoToHomePage();
        void Redirect(String path);
        void GoToAccountLoginPage();
        void GoToAccountRegisterPage();
        void GoToAccountEditAccountPage();
        void GoToAccountRecoverPasswordPage();
        void GoToAccountAccessDenied();
        void GoToProfilesProfile();
        void GoToFriendInvite();
        void GoToAccountLoginPage(string FriendInvitationKey);
        void GoToAccountRegisterPage(string FriendInvitationKey);
        void GotoSearch(string SearchText);
        void GoToFriendsInviteFriends(Int32 AccountIdToInvite);
        void GoToShowFriends();
        void GotoManageProfile();
        void GoToForumsForumView(string ForumPageName, string CategoryPageName);
    }
}
