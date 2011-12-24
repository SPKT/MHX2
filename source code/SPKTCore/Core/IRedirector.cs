using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SPKTCore.Core
{

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

        void GoToGroupsManageGroup(int GroupID);
        void GoToGroupsMembers(int GroupID, int PageNumber);
        void GoToGroupsViewGroup(int GroupID);
        void GoToGroupsMembers(int GroupID);
        void GoToGroupsViewGroup(string GroupPageName);
        void GoToPhotosMyPhotos();
        void GoToPhotosAddPhotos(Int64 AlbumID);
        void GoToPhotos();
        void GoToPhotosViewAlbum(Int64 AlbumID);
        void GoToPhotosEditPhotos(Int64 AlbumID);
        void GoToPhotosEditAlbum(Int64 AlbumID);
        void GoToBlogsPostEdit(Int64 BlogID);
       
        void GoToForumsViewPost(string ForumPageName, string CategoryPageName, string PostPageName);
        void GotoViewPostForum(long PostID);

        string PathViewAllForums { get;  }

        string PathViewForum { get;  }

        string PathViewForumCategory { get;  }

        string PathViewForumPost { get; }

        void GoToForums();
    }
}
