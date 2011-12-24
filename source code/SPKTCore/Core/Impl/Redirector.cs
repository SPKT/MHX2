using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using SPKTCore.Core;

namespace SPKTCore.Core.Impl
{

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
        public void GotoViewPostForum(long PostID)
        {
            Redirect("~/Forums/ViewPost1.aspx?PostID=" + PostID.ToString());
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
            Redirect("~/Accounts/ManageAccount.aspx");
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
        public void GoToGroupsManageGroup(int GroupID)
        {
            Redirect("~/Groups/ManageGroup.aspx?GroupID=" + GroupID.ToString());
        }
        //CHAPTER 10
        public void GoToGroupsMembers(int GroupID, int PageNumber)
        {
            Redirect("~/Groups/Members.aspx?GroupID=" + GroupID.ToString() + "&PageNumber=" + PageNumber.ToString());
        }
        //CHAPTER 10
        public void GoToGroupsViewGroup(int GroupID)
        {
            Redirect("~/Groups/ViewGroup.aspx?GroupID=" + GroupID.ToString());
        }
        //CHAPTER 10
        public void GoToGroupsMembers(int GroupID)
        {
            Redirect("~/Groups/Members.aspx?GroupID=" + GroupID.ToString());
        }
        //CHAPTER 10
        public void GoToGroupsViewGroup(string GroupPageName)
        {
            Redirect("~/Groups/" + GroupPageName + ".aspx");
        }
        //CHAPTER 9
        public void GoToForumsViewPost(string ForumPageName, string CategoryPageName, string PostPageName)
        {
            Redirect("~/Forums/" + CategoryPageName + "/" + ForumPageName + "/" + PostPageName + ".aspx");
        }

        public void GoToBlogsPostEdit(Int64 BlogID)
        {
            Redirect("~/Blogs/Post.aspx?BlogID=" + BlogID.ToString());
        }
        public void GoToPhotosMyPhotos()
        {
            Redirect("~/Photos/MyPhotos.aspx");
        }
        public void GoToPhotosEditAlbum(Int64 AlbumID)
        {
            Redirect("~/Photos/EditAlbum.aspx?AlbumID=" + AlbumID.ToString());
        }

        public void GoToPhotosEditPhotos(Int64 AlbumID)
        {
            Redirect("~/Photos/EditPhotos.aspx?AlbumID=" + AlbumID.ToString());
        }

        public void GoToPhotosViewAlbum(Int64 AlbumID)
        {
            Redirect("~/Photos/ViewAlbum.aspx?AlbumID=" + AlbumID.ToString());
        }
        public void GoToPhotos()
        {
            Redirect("~/Photos/Default.aspx");
        }

       public void GoToPhotosAddPhotos(Int64 AlbumID)
        {
            Redirect("~/Photos/AddPhotos.aspx?AlbumID=" + AlbumID.ToString());
        }


       public string PathViewAllForums
       {
           get
           {
              return "/forums/AllForums.aspx";
           }
       }

       public string PathViewForum
       {
           get
           {
               return "/forums/ViewForum1.aspx";
           }
       }

       public string PathViewForumCategory
       {
           get
           {
            return "/forums/AllForum.aspx";
           }
       }
       public string PathViewForumPost
       {
           get
           {
               return "/forums/ViewPost1.aspx";
           }
       }
    }
}