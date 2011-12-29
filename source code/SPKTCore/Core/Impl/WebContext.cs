using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using SPKTCore.Core.Domain;
using System.Web.Security;

namespace SPKTCore.Core.Impl
{
    public class WebContext : IWebContext
    {
        public HttpFileCollection Files
        {
            get
            {
                if (HttpContext.Current.Request.Files != null)
                    return HttpContext.Current.Request.Files;
                else
                    return null;
            }
        }
        public string FilePath
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"].ToString();
            }
        }
        public bool ShowGravatar
        {
            get
            {
                if (!string.IsNullOrEmpty(GetQueryStringValue("ShowGravatar")) && GetQueryStringValue("ShowGravatar") == "1")
                {
                    return true;
                }
                return false;
            }
        }

        public Int32 AccountID
        {
            get
            {
                if (!string.IsNullOrEmpty(GetQueryStringValue("AccountID")))
                {
                    return Convert.ToInt32(GetQueryStringValue("AccountID"));
                }
                return 0;
            }
        }
        public string CaptchaImageText
        {
            get
            {
                if(ContainsInSession("CaptchaImageText"))
                {
                    return GetFromSession("CaptchaImageText").ToString();
                }

                return null;
            }
            set
            {
                SetInSession("CaptchaImageText",value);
            }
        }
        public Account CurrentUser
        {
            get
            {
                if (!LoggedIn)
                    return null;
                if (!ContainsInSession("CurrentUser"))
                    SetLogedInSession(Username);
                return GetFromSession("CurrentUser") as Account;
            }
            set
            {
                SetInSession("CurrentUser", value);
            }
        }
        public Profile CurrentProfile
        {
            get
            {
                if (!LoggedIn)
                    return null;
                if (!ContainsInSession("CurrentProfile"))
                    SetLogedInSession(Username);
                return GetFromSession("CurrentProfile") as Profile;
            }
            set
            {
                SetInSession("CurrentProfile", value);
            }
        }
      
        public string Username
        {
            get
            {
                if (LoggedIn)
                    return HttpContext.Current.User.Identity.Name;
                return null;                
            }
        }

        //public void SaveLoginInfoToCookie(String username, String password)
        //{
        //    HttpCookie cook = new HttpCookie("Login");
        //    cook["Username"] = username;
        //    cook["Password"] = password;
        //    cook.Expires = DateTime.Now.AddDays(20);
        //    WriteToCookie(cook);
        //}
        
        public bool LoggedIn
        {
            get
            {
                return (HttpContext.Current.User.Identity != null && HttpContext.Current.User.Identity.IsAuthenticated);
            }   
        }

        private HttpCookie GetInCookie(string name)
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null)
            {
                return null;
            }
            return HttpContext.Current.Request.Cookies[name];
        }
        private void WriteToCookie(HttpCookie value)
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null)
            {
                return ;
            }

            HttpContext.Current.Response.Cookies.Add(value);
        }
        public void RemoveCookie(string name)
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null)
            {
                return;
            }
            HttpCookie ck = new HttpCookie(name);
            ck.Expires = DateTime.Now.AddDays(-2);
            HttpContext.Current.Response.Cookies.Add(ck);
        }
        //lay username từ chuỗi mã hóa trong link xác nhận mail
        public string UsernameToVerify
        {
            get
            {
                return GetQueryStringValue(ParameterSetting.UsernameToVerifyQueryStringName).ToString();
            }
        }

        public void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }

        public bool ContainsInSession(string key)
        {
            return HttpContext.Current.Session[key] != null;
        }

        public void RemoveFromSession(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }
        // lấy giá trị key của query string
        public string GetQueryStringValue(string key)
        {
            return HttpContext.Current.Request.QueryString[key];
        }


        private void SetInSession(string key, object value)
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null)
            {
                return;
            }
            HttpContext.Current.Session[key] = value;
        }

        private object GetFromSession(string key)
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null)
            {
                return null;
            }
            return HttpContext.Current.Session[key];
        }

        private void UpdateInSession(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }


        public string RootUrl
        {
            get
            {
                string result;

                string Port = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
                if (Port == null || Port == "80" || Port == "443")
                    Port = "";
                else
                    Port = ":" + Port;

                string Protocol = HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
                if (Protocol == null || Protocol == "0")
                    Protocol = "http://";
                else
                    Protocol = "https://";

                result = Protocol + HttpContext.Current.Request.ServerVariables["SERVER_NAME"] +
                    Port + HttpContext.Current.Request.ApplicationPath;

                return result;
            }
        }
        public Int32 AccoundIdToInvite
        {
            get
            {
                Int32 result;
                if (!string.IsNullOrEmpty(GetQueryStringValue("AccountIdToInvite")))
                {
                    result = Convert.ToInt32(GetQueryStringValue("AccountIdToInvite"));
                }
                else
                {
                    result = 0;
                }
                return result;
            }
        }
        public string SearchText
        {
            get
            {
                string result;
                if (!string.IsNullOrEmpty(GetQueryStringValue("s")))
                {
                    result = GetQueryStringValue("s");
                }
                else
                {
                    result = "";
                }
                return result;
            }
        }
        public string FriendshipRequest
        {
            get
            {
                string result;
                if (!string.IsNullOrEmpty(GetQueryStringValue("InvitationKey")))
                {
                    result = GetQueryStringValue("InvitationKey");
                }
                else
                {
                    result = "";
                }
                return result;
            }
        }
        //moi
        public Int32 FolderID
        {
            get
            {
                Int32 result;
                if (!string.IsNullOrEmpty(GetQueryStringValue("Folder")))
                    result = Convert.ToInt32(GetQueryStringValue("Folder"));
                else
                    result = 1;
                return result;
            }
        }
        public Int32 MessageID
        {
            get
            {
                Int32 result;
                if (!string.IsNullOrEmpty(GetQueryStringValue("MessageID")))
                    result = Convert.ToInt32(GetQueryStringValue("MessageID"));
                else
                    result = 0;
                return result;
            }
        }
        public Int32 PageNumber
        {
            get
            {
                Int32 result;
                if (!string.IsNullOrEmpty(GetQueryStringValue("PageNumber")))
                    result = Convert.ToInt32(GetQueryStringValue("PageNumber"));
                else
                    result = 1;
                return result;
            }
        }

        public Int32 GroupID
        {
            get
            {
                Int32 result = 0;
                if (!string.IsNullOrEmpty(GetQueryStringValue("GroupID")))
                {
                    result = Convert.ToInt32(GetQueryStringValue("GroupID"));
                }
                return result;
            }
        }

        public bool IsThread
        {
            get
            {
                bool result = false;
                if (!string.IsNullOrEmpty(GetQueryStringValue("IsThread")))
                {
                    if (GetQueryStringValue("IsThread") == "1")
                        result = true;
                }
                return result;
            }
        }
        public Int32 ForumID
        {
            get
            {
                Int32 result = 0;
                if (!string.IsNullOrEmpty(GetQueryStringValue("ForumID")))
                {
                    result = Convert.ToInt32(GetQueryStringValue("ForumID"));
                }
                return result;
            }
        }

        public int FileTypeID
        {
            get { throw new NotImplementedException(); }
        }

        public long BlogID
        {
            get { throw new NotImplementedException(); }
        }



        public long PostID
        {
            get
            {
                Int64 result = 0;
                if (!string.IsNullOrEmpty(GetQueryStringValue("PostID")))
                {
                    result = Convert.ToInt64(GetQueryStringValue("PostID"));
                }
                return result;
            }
        }




        public Int64 AlbumID
        {
            get
            {
                Int64 result;
                if (!string.IsNullOrEmpty(GetQueryStringValue("AlbumID")))
                    result = Convert.ToInt64(GetQueryStringValue("AlbumID"));
                else
                    result = 0;

                return result;
            }
        }

        public string CategoryPageName
        {
            get
            {
                string result = "";
                if (!string.IsNullOrEmpty(GetQueryStringValue("CategoryPageName")))
                {
                    result = GetQueryStringValue("CategoryPageName");
                }
                return result;
            }
        }

        public string ForumPageName
        {
            get
            {
                string result = "";
                if (!string.IsNullOrEmpty(GetQueryStringValue("ForumPageName")))
                {
                    result = GetQueryStringValue("ForumPageName");
                }
                return result;
            }
        }


        public string ReturnURL
        {
            get {
                return GetQueryStringValue("ReturnUrl");
            }
        }

        public void Login(string username,bool remember)
        {
            FormsAuthentication.SetAuthCookie(username, remember);
            SetLogedInSession(username);
        }

        private void SetLogedInSession(string username)
        {
            IAccountService accountService = new AccountService();
            Account account = accountService.GetAccountByUsername(username);
            IUserSession _userSession = new UserSession();            
            _userSession.CurrentUser = account;
            _userSession.CurrentProfile = account.Profile;
        }

        public void Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            ClearLogedinSession();
            IRedirector _redirector = new Redirector();
            _redirector.GoToAccountLoginPage();
        }

        private static void ClearLogedinSession()
        {
            IUserSession _userSession = new UserSession();            
            _userSession.CurrentUser = null;     
        }
    }

 }
