using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;
using System.Web;

namespace SPKTCore.Core
{
    public interface IWebContext
    {
        void ClearSession();
        void RemoveCookie(string name);
        void SaveLoginInfoToCookie(String username, String password);
        bool ContainsInSession(string key);
        void RemoveFromSession(string key);
        bool LoggedIn { get; set; }
        Account CurrentUser { get; set; }
        Profile CurrentProfile { get; set; }
        string Username { get; set; }
        string CaptchaImageText { get; set; }
        string GetQueryStringValue(string key);
        String UsernameToVerify { get; }
        bool ShowGravatar { get; }
        string RootUrl { get; }
        Int32 AccountID { get; }
        string FriendshipRequest { get; }
        string SearchText { get; }
        Int32 AccoundIdToInvite { get; }
        //moi
        Int32 MessageID { get; }
        Int32 FolderID { get; }
        Int32 PageNumber { get; }
        Int64 AlbumID { get; }
        Int32 FileTypeID { get; }
        Int64 BlogID { get; }
        Int32 ForumID { get; }
        Int64 PostID { get; }
        bool IsThread { get; }
        string CategoryPageName { get; }
        string ForumPageName { get; }
        Int32 GroupID { get; }
        string FilePath { get; }
        HttpFileCollection Files { get; }
    }
}
