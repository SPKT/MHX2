using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTWeb.Profiles.Interface;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Impl;

namespace SPKTWeb.Profiles.Presenter
{
    public class ViewProfilePresenter
    {
        private IViewProfile _view;
        private IProfileRepository _profileRepository;
        private ILevelOfExperienceRepository _levelOfExperienceRepository;
        public IProfileAttributeRepository _profileAttributeRepository;
        private IUserSession _userSession;
        private IProfileService _profileService;
        private IProfileAttributeService _profileAttributeService;
        private IRedirector _redirector;
        private List<ProfileAttributeType> _listProfileAttributeType;
        private IPrivacyService _privacyService;
        List<PrivacyFlag> _listPrivacyFlags;
        List<VisibilityLevel> _listVisibilityLevel;
        Profile profile;
        int accountID;
        int viewerID = -1;
        IWebContext _webContext;

        IAccountRepository _accountRepository;
        public ViewProfilePresenter()
        {
            _levelOfExperienceRepository = new LevelOfExperienceRepository();
            _profileAttributeRepository = new ProfileAttributeRepository();
            _profileRepository = new ProfileRepository();
            _userSession = new UserSession();
            _profileService = new ProfileService();
            _profileAttributeService = new ProfileAttributeService();
            _redirector = new Redirector();
            _listProfileAttributeType = new List<ProfileAttributeType>();
            _listPrivacyFlags = new List<PrivacyFlag>();
            _privacyService = new PrivacyService();
            _listVisibilityLevel = new List<VisibilityLevel>();
            profile = new Profile();
            _accountRepository = new AccountRepository();

            _webContext = new WebContext();
 
        }
        public void Init(IViewProfile view, bool IsPostback)
        {
            _view = view;
            accountID = _webContext.AccountID;
                if (_userSession.LoggedIn)
                {
                    viewerID = _userSession.CurrentUser.AccountID;
                  

                }
                if (accountID == 0)
                {
                    _view.DisplayAccountInfo(viewerID, viewerID);
                    accountID = viewerID;
                }
                else
                {
                    _view.DisplayAccountInfo(viewerID, accountID);
                    
                    //_view.loadProfileAttribute(_listProfileAttributeType, profile);
                }
                
                LoadProfile(IsPostback,accountID);
                profile = _profileService.LoadProfileByAccountID(accountID);
                _listPrivacyFlags = _privacyService.GetListPrivacyFlag(profile.ProfileID);
                _listProfileAttributeType = _profileAttributeService.GetProfileAttributeType();
                _view.loadProfileAttribute(_listProfileAttributeType, profile);
           // }
        }

        public void LoadProfile(bool IsPostback, int AccountID)
        {
            Profile profile = _profileService.LoadProfileByAccountID(AccountID);
            if (!IsPostback)
            {
                
                if (profile != null)
                {
                    
                    _view.LoadProfile(profile, _listVisibilityLevel);
                }
                
            }
            

        }
        public bool IsAttributeVisible(Int32 PrivacyFlagTypeID)
        {
            return _privacyService.ShouldShow(PrivacyFlagTypeID, _accountRepository.GetAccountByID(accountID), _accountRepository.GetAccountByID(viewerID), _listPrivacyFlags);
        }
        public List<PrivacyFlagType> GetProfileAttribute(Account AccountBeingViewed, Account account)
        {
            return _privacyService.GetListPrivacyFlagType(account, AccountBeingViewed);
            
        }
        public Profile GetProfile()
        {
            return _profileService.LoadProfileByAccountID(_userSession.CurrentUser.AccountID);
                
        }

        public Account GetAccount()
        {
            return _userSession.CurrentUser;
        }

  
        public List<ProfileAttributeType> GetProfileAttributeTypes()
        {
            return _profileAttributeRepository.GetProfileAttributeTypes();
        }

        public List<ProfileAttribute> GetProfileAttributeByProfileID(Profile profile)
        {
            return _profileAttributeService.GetProfileAttributesByProfileID(profile.ProfileID);

        }

        public ProfileAttribute GetProfileAttributeByProfileIDAndType(Profile profile, ProfileAttributeType type)
        {
            return _profileAttributeService.GetProfileAttributesByProfileIDAndTypeID(profile, type);
        }


        public void GotoUpdateAvatar()
        {
            _redirector.Redirect("~/Profiles/UpLoadAvatar.aspx");
        }


    }
}