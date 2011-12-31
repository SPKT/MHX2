using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Impl;

namespace SPKTWeb.Photo.UserControl
{
    public partial class ReadFile : System.Web.UI.UserControl
    {
        private IProfileRepository _profileRepository;
        private IUserSession _userSession;
        private IAccountRepository _accountRepository;
        private IWebContext _webContext;

        private Int32 accountID;
        private Account account;
        private File file;
        FileRepository _fr;
        private string gravatarURL;
        private string defaultAvatar;
        public long fileID;
        public long getfileID()
        {
            return fileID;
        }
        public void setfileID(long id)
        {
            fileID = id;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //_profileRepository = new ProfileRepository();
            _fr = new FileRepository();
            _userSession = new UserSession();
            _accountRepository = new AccountRepository();
            _webContext = new WebContext();

            
                if (_userSession.LoggedIn && _userSession.CurrentUser != null)
                {
                    account = _userSession.CurrentUser;
                    file = _fr.GetFileByID(fileID);
                }
            
            //show the appropriate image

            if (file != null)
            {

                //Response.Clear();
                Response.ContentType = "jpg";
                Response.BinaryWrite(file.ContentFile.ToArray());

            }

        }
        public string GetGravatarURL()
        {
            defaultAvatar = Server.UrlPathEncode(_webContext.RootUrl + "~/Image/ALIEN_01_01.jpg");

            gravatarURL = "http://www.gravatar.com/avatar.php?";
            gravatarURL += "gravatar_id=" + account.Email.Encrypt("key");
            gravatarURL += "&rating=r";
            gravatarURL += "&size=80";
            gravatarURL += "&default=" + defaultAvatar;
            return gravatarURL;
        }
    }
}