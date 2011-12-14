using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;

namespace SPKTCore.Core.Impl
{
    public class AlertService:IAlertService
    {
        private IUserSession _userSession;
        private IAlertRepository _alertRepository;
        private IWebContext _webContext;
        private IFriendRepository _friendRepository;
        private IAccountRepository _accountRepository;
        private IGroupMemberRepository _groupMemberRepository;
        private Account account;
        private Alert alert;
        private string alertMessage;
        private string[] tags = { "[rootUrl]" };
        public AlertService()
        {
            _userSession = new UserSession();
            _alertRepository = new AlertRepository();
            _webContext = new WebContext();
            _friendRepository = new FriendRepository();
            alert = new Alert();
            _accountRepository = new AccountRepository();
            _groupMemberRepository = new GroupMemberRepository();
        }

        private void Init()
        {
            account = _userSession.CurrentUser;
            alert = new Alert();
            alert.AccountID = account.AccountID;
            alert.CreateDate = DateTime.Now;
        }

        public void AddAccountCreatedAlert()
        {
            Init();
            alertMessage = "<div class=\"AlertHeader\">" + GetProfileUrl(account.UserName) + " just signed up!</div>";
            alertMessage += "<div class=\"AlertRow\">" + GetSendMessageUrl(account.AccountID) + "</div>";
            alert.Message = alertMessage;
            alert.AlertTypeID = (int)AlertType.AlertTypes.AccountCreated;
            SaveAlert(alert);
        }

        public void AddAccountModifiedAlert()
        {
            Init();
            alertMessage = "<div class=\"AlertHeader\">" + GetProfileUrl(account.UserName) +
                           " modified their account.</div>";
            alert.Message = alertMessage;
            alert.AlertTypeID = (int)AlertType.AlertTypes.AccountModified;
            SaveAlert(alert);
        }

        public void AddProfileCreatedAlert()
        {
            Init();
            alertMessage = "<div class=\"AlertHeader\">" + GetProfileUrl(account.UserName) +
                           " vừa mới tạo Profile</div>";
            alertMessage += "<div class=\"AlertRow\">" + GetSendMessageUrl(account.AccountID) + "</div>";
            alert.CreateDate = DateTime.Now;
            alert.Message = alertMessage;
            alert.AlertTypeID = (int)AlertType.AlertTypes.ProfileCreated;
            SaveAlert(alert);
        }

        public void AddProfileModifiedAlert()
        {
            Init();
            alertMessage = "<div class=\"AlertHeader\">" +"<a href='/UserProfile2.aspx?AccountID='"+account.UserName+"</a>" +
                           " vừa mới thay đổi thông tin cá nhân.</div>";
            alert.Message = alertMessage;
            alert.AlertTypeID = (int)AlertType.AlertTypes.ProfileModified;
            SaveAlert(alert);
        }
        public void AddStatusUpdateAlert(StatusUpdate statusUpdate)
        {
            Init();
            
            alert.CreateDate = DateTime.Now;
            alert.AccountID = statusUpdate.SenderID;
            alert.AlertTypeID = (int)AlertType.AlertTypes.StatusUpdate;
            //alertMessage = "<div class=\"AlertHeader\">" +  
                            //GetProfileImage(_userSession.CurrentUser.AccountID)  
                            //+ GetProfileUrl(_userSession.CurrentUser.UserName) +
                            //"   " + statusUpdate.Status + "</div>";

            alertMessage ="<a href='/UserProfile2.aspx?AccountID='"+ _accountRepository.GetAccountByID(statusUpdate.SenderID).UserName+"</a" + " viết lên tường nhà "
                    +"<a href='~/Profiles/UserProfile2.aspx?AccountID='"+ _accountRepository.GetAccountByID((int)statusUpdate.AccountID).UserName+"<\a>" + " : " + statusUpdate.Status;
           
            alert.Message = alertMessage;
            SaveAlert(alert);
            //SendAlertToFriends(alert);
        }
        private string GetProfileImage(Int32 AccountID)
        {
            return "<img width=\"50\" height=\"50\" src=\"~/image/ProfileAvatar.aspx?AccountID=" +
                   AccountID.ToString() + "&w=50&h=50\" align=\"absmiddle\">";
        }

        public void AddNewAvatarAlert()
        {
            Init();
            alertMessage =
                "<div class=\"AlertHeader\"><img src=\"~/image/ProfileAvatar.aspx?AccountID=" +
                account.AccountID.ToString() + "\" width=\"100\" height=\"100\" align=\"absmiddle\">" + GetProfileUrl(account.UserName) + " đổi avatar mới.</div>";
            alert.Message = alertMessage;
            alert.AlertTypeID = (int)AlertType.AlertTypes.NewAvatar;
            SaveAlert(alert);
        }

        public List<Alert> GetAlertsByAccountID(Int32 AccountID)
        {
            List<Alert> result = new List<Alert>();
            List<Alert> alerts = _alertRepository.GetAlertsByAccountID(AccountID);
            foreach (Alert alert in alerts)
            {
                foreach (string s in tags)
                {
                    switch (s)
                    {
                        case "[rootUrl]":
                            alert.Message = alert.Message.Replace("[rootUrl]", _webContext.RootUrl);
                            result.Add(alert);
                            break;
                    }
                }
            }

            return result;
        }

        private void SaveAlert(Alert alert)
        {
            _alertRepository.SaveAlert(alert);
        }

        private string GetProfileUrl(string UserName)
        {
            return "<a href=\"[rootUrl]" + account.UserName + "\">" + account.UserName + "</a>";
        }

        private string GetSendMessageUrl(Int32 AccountID)
        {
            return "Nhấp vào đây để gửi tin nhắn";
        }


        public List<Alert> GetAlerts(int viewerID, int AccountID)
        {
            List<Alert> result = new List<Alert>();
            List<Alert> alerts = _alertRepository.GetAlertsByAccountID(AccountID);
            //foreach (Alert alert in alerts)
            //{
            //    foreach (string s in tags)
            //    {
            //        switch (s)
            //        {
            //            case "[rootUrl]":
            //                alert.Message = alert.Message.Replace("[rootUrl]", _webContext.RootUrl);
            //                result.Add(alert);
            //                break;
            //        }
            //    }
            //}

            return alerts;
        }
        private void SendAlertToGroup(Alert alert, Group group)
        {
            List<int> groupMembers = _groupMemberRepository.GetMemberAccountIDsByGroupID(group.GroupID);
            foreach (int id in groupMembers)
            {
                alert.AlertID = 0;
                alert.AccountID = id;
                SaveAlert(alert);
            }
        }

        private void SendAlertToFriends(Alert alert)
        {
            List<Friend> friends = _friendRepository.GetFriendsByAccountID(alert.AccountID);
            foreach (Friend friend in friends)
            {
                alert.AlertID = 0;
                alert.AccountID = friend.MyFriendAccountID;
                SaveAlert(alert);
            }
        }
        public void AddNewBoardPostAlert(BoardCategory category, BoardForum forum, BoardPost post, BoardPost thread, Group group)
        {
            Init();
            alert.AlertTypeID = (int)AlertType.AlertTypes.NewBoardPost;
            alertMessage = "<div class=\"AlertHeader\">" + GetProfileImage(_userSession.CurrentUser.AccountID) +
                           GetProfileUrl(_userSession.CurrentUser.UserName) + " has just added a new post: <b>" +
                           post.Name + "</b></div>";

            alertMessage += "<div class=\"AlertRow\"><a href=\"" + _webContext.RootUrl + "forums/" + category.PageName +
                           "/" + forum.PageName + "/" + thread.PageName + ".aspx" + "\">" + _webContext.RootUrl +
                           "forums/" + category.PageName + "/" + forum.PageName + "/" + thread.PageName +
                           ".aspx</a></div>";
            alert.Message = alertMessage;
            SaveAlert(alert);
            SendAlertToGroup(alert, group);
        }


        public void AddNewBoardThreadAlert(BoardCategory category, BoardForum forum, BoardPost post, Group group)
        {
            Init();
            alert.AlertTypeID = (int)AlertType.AlertTypes.NewBoardThread;
            alertMessage = "<div class=\"AlertHeader\">" + GetProfileImage(_userSession.CurrentUser.AccountID) +
                           GetProfileUrl(_userSession.CurrentUser.UserName) + " has just added a new thread on the board: <b>" +
                           post.Name + "</b></div>";

            alertMessage += "<div class=\"AlertRow\"><a href=\"" + _webContext.RootUrl + "forums/" + category.PageName +
                           "/" + forum.PageName + "/" + post.PageName + ".aspx" + "\">" + _webContext.RootUrl +
                           "forums/" + category.PageName + "/" + forum.PageName + "/" + post.PageName +
                           ".aspx</a></div>";
            alert.Message = alertMessage;
            SaveAlert(alert);
            SendAlertToGroup(alert, group);
        }

        public void AddNewBoardPostAlert(BoardCategory category, BoardForum forum, BoardPost post, BoardPost thread)
        {
            Init();
            alert.AlertTypeID = (int)AlertType.AlertTypes.NewBoardPost;
            alertMessage = "<div class=\"AlertHeader\">" + GetProfileImage(_userSession.CurrentUser.AccountID) +
                           GetProfileUrl(_userSession.CurrentUser.UserName) + " has just added a new post: <b>" +
                           post.Name + "</b></div>";

            alertMessage += "<div class=\"AlertRow\"><a href=\"" + _webContext.RootUrl + "forums/" + category.PageName +
                           "/" + forum.PageName + "/" + thread.PageName + ".aspx" + "\">" + _webContext.RootUrl +
                           "forums/" + category.PageName + "/" + forum.PageName + "/" + thread.PageName +
                           ".aspx</a></div>";
            alert.Message = alertMessage;
            SaveAlert(alert);
            SendAlertToFriends(alert);
        }

         public void AddNewBoardThreadAlert(BoardCategory category, BoardForum forum, BoardPost post)
        {
            Init();
            alert.AlertTypeID = (int)AlertType.AlertTypes.NewBoardThread;
            alertMessage = "<div class=\"AlertHeader\">" + GetProfileImage(_userSession.CurrentUser.AccountID) +
                           GetProfileUrl(_userSession.CurrentUser.UserName) + " has just added a new thread on the board: <b>" +
                           post.Name + "</b></div>";

            alertMessage += "<div class=\"AlertRow\"><a href=\"" + _webContext.RootUrl + "forums/" + category.PageName +
                           "/" + forum.PageName + "/" + post.PageName + ".aspx" + "\">" + _webContext.RootUrl +
                           "forums/" + category.PageName + "/" + forum.PageName + "/" + post.PageName +
                           ".aspx</a></div>";
            alert.Message = alertMessage;
            SaveAlert(alert);
            SendAlertToFriends(alert);
        }

          public void AddNewBlogPostAlert(Blog blog)
        {
            alert = new Alert();
            alert.CreateDate = DateTime.Now;
            alert.AccountID = _userSession.CurrentUser.AccountID;
            alert.AlertTypeID = (int)AlertType.AlertTypes.NewBlogPost;
            alertMessage = "<div class=\"AlertHeader\">" + GetProfileImage(_userSession.CurrentUser.AccountID) +
                           GetProfileUrl(_userSession.CurrentUser.UserName) + " has just added a new blog post: <b>" +
                           blog.Title + "</b></div>";
            alert.Message = alertMessage;
            SaveAlert(alert);
            SendAlertToFriends(alert);
        }

        public void AddUpdatedBlogPostAlert(Blog blog)
        {
            alert = new Alert();
            alert.CreateDate = DateTime.Now;
            alert.AccountID = _userSession.CurrentUser.AccountID;
            alert.AlertTypeID = (int)AlertType.AlertTypes.NewBlogPost;
            alertMessage = "<div class=\"AlertHeader\">" + GetProfileImage(_userSession.CurrentUser.AccountID) +
                           GetProfileUrl(_userSession.CurrentUser.UserName) + " has updated the <b>" + blog.Title +
                           "</b> blog post!</div>";
            alert.Message = alertMessage;
            SaveAlert(alert);
            SendAlertToFriends(alert);
        }

    }
}
