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

namespace SPKTWeb.Image
{
    public partial class ProfileAvatar : System.Web.UI.Page
    {
        private IProfileRepository _profileRepository;
        private IUserSession _userSession;
        private IAccountRepository _accountRepository;
        private IWebContext _webContext;

        private Int32 accountID;
        private Account account;
        private Profile profile;
        private string gravatarURL;
        private string defaultAvatar;
        protected void Page_Load(object sender, EventArgs e)
        {
            _profileRepository = new ProfileRepository();
            _userSession =new UserSession();
            _accountRepository = new AccountRepository();
            _webContext = new WebContext();

            //load an image by passed in accountid
            //if (_webContext.AccoundIdToInvite> 0)
            //{
            //    accountID = _webContext.AccoundIdToInvite;
            //    profile = _profileRepository.GetProfileByAccountID(accountID);
            //    account = _accountRepository.GetAccountByID(accountID);
            //}
           
            if (_webContext.AccountID> 0)
            {
                accountID = _webContext.AccountID;
                profile = _profileRepository.GetProfileByAccountID(accountID);
                account = _accountRepository.GetAccountByID(accountID);
            }
            //get an image for the current user
            else
            {
                if (_userSession.LoggedIn && _userSession.CurrentUser != null)
                {
                    account = _userSession.CurrentUser;
                    profile = _profileRepository.GetProfileByAccountID(account.AccountID);
                }
            }

            //show the appropriate image
            if (_webContext.ShowGravatar || (profile != null &&  profile.UseGrAvatar == 1))
            {
                Response.Redirect(GetGravatarURL());
            }
            else if (profile != null && profile.Avatar != null)
            {
                Response.Clear();
                Response.ContentType = profile.AvatarMimeType;
                Response.BinaryWrite(profile.Avatar.ToArray());
            }
            else
            {
                Response.Redirect("~/Image/ALIEN_01_01.jpg");
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