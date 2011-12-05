using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using StructureMap;
using SPKTCore.Core;

namespace SPKTCore.Core.Impl
{
    [Pluggable("Default")]
    public class Redirector : IRedirector
    {
        public void GotoManageProfile()
        {
            Redirect("~/Profiles/ManageProfile.aspx");
        }
        public void GoToAccountAccessDenied()
        {
            Redirect("~/Accounts/AccessDenied.aspx");

        }

        public void GoToAccountRecoverPasswordPage()
        {
            Redirect("~/Accounts/RecoverPassword.aspx");
        }

        public void GoToAccountEditAccountPage()
        {
            Redirect("~/Accounts/EditAccount.aspx");
        }

        public void GoToAccountLoginPage()
        {
            Redirect("~/Accounts/Login.aspx");
        }

        public void GoToAccountRegisterPage()
        {
            Redirect("~/Accounts/Register.aspx");
        }

        public void GoToHomePage()
        {
            Redirect("~/Homes/Home.aspx");
        }

        public void GoToErrorPage()
        {
            Redirect("~/Error.aspx");
        }

        public void Redirect(string path)
        {
            HttpContext.Current.Response.Redirect(path);
        }

        public void GotoHomePage()
        {
            Redirect("~/Home/Home.aspx");
        }



        public void GoToProfilesProfile()
        {
            Redirect("~/Profiles/UserProfile2.aspx");
        }

        ///
        public void GoToAccountLoginPage(string FriendInvitationKey)
        {
            Redirect("~/Accounts/Login.aspx?InvitationKey=" + FriendInvitationKey);
        }

        public void GoToAccountRegisterPage(string FriendInvitationKey)
        {
            Redirect("~/Accounts/Register.aspx?InvitationKey=" + FriendInvitationKey);
        }
        public void GotoSearch(string SearchText)
        {
            Redirect("~/Searchs/Search.aspx?s=" + SearchText);
        }
        public void GoToFriendsInviteFriends(Int32 AccoundIdToInvite)
        {
            Redirect("~/Friends/Invite.aspx?AccountIdToInvite=" + AccoundIdToInvite.ToString());
        }
        public void GoToShowFriends()
        {
            Redirect("~/Friends/ShowFriend.aspx?");
        }
        public void GoToFriendInvite()
        {
            Redirect("~/Friends/Invite.aspx");
        }
        public void GotoVisitFriend(Int32 Acc)
        {
            Redirect("~/Profiles/UserProfile2.aspx?AccountID=" + Acc);
        }

        public void GoToForumsForumView(string ForumPageName, string CategoryPageName)
        {

            Redirect("~/Forums/" + CategoryPageName + "/" + ForumPageName + ".aspx");
        }
    }
}