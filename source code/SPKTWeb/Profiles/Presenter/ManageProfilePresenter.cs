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
    public class ManageProfilePresenter
    {
        private IManageProfile _view;
        private IProfileRepository _profileRepository;
        private ILevelOfExperienceRepository _levelOfExperienceRepository;
        public IProfileAttributeRepository _profileAttributeRepository;
        private IUserSession _userSession;
        private IProfileService _profileService;
        private IProfileAttributeService _profileAttributeService;
        private IRedirector _redirector;
        private List<ProfileAttributeType> _listProfileAttributeType;
        private IPrivacyRepository _privacyRepository;
        List<PrivacyFlag> _listPrivacyFlags;
        List<VisibilityLevel> _listVisibilityLevel;
        Profile profile;
        public ManageProfilePresenter()
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
            _privacyRepository = new PrivacyRepository();
            _listVisibilityLevel = new List<VisibilityLevel>();
            profile = new Profile();
        }

        public void Init(IManageProfile view, bool IsPostback)
        {
            _view = view;
            if (_userSession.LoggedIn == true)
            {
                _listVisibilityLevel = _privacyRepository.GetVisibilityLevels();
                
                profile = _profileService.LoadProfileByUserName(_userSession.Username);
                _listProfileAttributeType = _profileAttributeService.GetProfileAttributeType();
                if (profile != null)
                {
                    _listPrivacyFlags = _privacyRepository.GetPrivacyFlagsByProfileID(profile.ProfileID);
                    _view.loadProfileAttribute(_listProfileAttributeType,_listVisibilityLevel,_listPrivacyFlags, profile);
             
                }
                else
                {
                    profile = new Profile();
                    profile.AccountID = _userSession.CurrentUser.AccountID;
                    profile.profileName = _userSession.CurrentUser.UserName;
                    _profileService.SaveProfileTable(profile);
                    AddProfileAttribute(_listProfileAttributeType, profile);
                   
                }
                //_view.LoadProfile(profile);
                _view.ShowProfileName(profile.profileName);
                LoadProfile(IsPostback);
            }
            else
            {
                _redirector.GoToAccountLoginPage();
            }
        }
        public void AddProfileAttribute(List<ProfileAttributeType> _listProfileAttributeType, Profile profile)
        {
            ProfileAttribute profileAttribute;
            foreach (ProfileAttributeType proAttributeType in _listProfileAttributeType)
            {
                
                profileAttribute = new ProfileAttribute();
                profileAttribute.ProfileID = profile.ProfileID;
                profileAttribute.ProfileAttributeName = proAttributeType.Type;
                profileAttribute.ProfileAttributeTypeID = proAttributeType.ProfileAttributeTypeID;
                _profileAttributeService.SaveProfileAttribute(profileAttribute);
            }
        }
        public void LoadProfile(bool IsPostback)
        {
            if (!IsPostback)
            {
                Profile profile = _profileService.LoadProfileByAccountID(_userSession.CurrentUser.AccountID);
                _view.LoadProfile(profile, _listVisibilityLevel);
            }
        }

        public Profile GetProfile()
        {
            return _profileService.LoadProfileByAccountID(_userSession.CurrentUser.AccountID);
                
        }

        public Account GetAccount()
        {
            return _userSession.CurrentUser;
        }

        public void SaveProfile(Profile profile)
        {
            _profileService.SaveProfile(profile);
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

        public void SaveAttribute(ProfileAttribute attribute)
        {
            _profileAttributeService.SaveProfileAttribute(attribute);
        }

        public void GotoUpdateAvatar()
        {
            _redirector.Redirect("~/Profiles/UpLoadAvatar.aspx");
        }
        public bool IsFlagSelected(int PrivacyFlagTypeID, int VisibilityLevelID, List<PrivacyFlag> PrivacyFlags)
        {
            List<PrivacyFlag> result = PrivacyFlags.Where(pf => pf.PrivacyFlagTypeID == PrivacyFlagTypeID && pf.VisibilityLevelID == VisibilityLevelID).ToList();
            if (result.Count > 0)
            {
                return true;
            }
            return false;
        }



        public List<PrivacyFlagType> GetPrivacyFlagTypes()
        {
            return _privacyRepository.GetPrivacyFlagTypes();
        }

        public List<PrivacyFlag> GetPrivacyFlag()
        {
            return _privacyRepository.GetPrivacyFlagsByProfileID(profile.ProfileID);
        }

        public void SavePrivacyFlag(int privacyTypeID, int visibilityID)
        {
            foreach (PrivacyFlag flag in _listPrivacyFlags)
            {
                if (flag.PrivacyFlagTypeID == privacyTypeID)
                {
                    flag.VisibilityLevelID = visibilityID;
                    _privacyRepository.SavePrivacyFlag(flag);
                    return;
                }
            }

           
            PrivacyFlag newFlag = new PrivacyFlag();
            newFlag.PrivacyFlagTypeID = privacyTypeID;
            newFlag.VisibilityLevelID = visibilityID;
            newFlag.ProfileID = profile.ProfileID;
            newFlag.CreateDate = DateTime.Now;
            _listPrivacyFlags.Add(newFlag);
            _privacyRepository.SavePrivacyFlag(newFlag);
        }
    }
}