using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess.Impl;

namespace SPKTCore.Core.Impl
{
    public class ProfileService : IProfileService
    {
        private IProfileRepository _profileRepository;
        private IProfileAttributeRepository _profileAttributeRepository;
        private IProfileAttributeService _profileAttributeService;
        private ILevelOfExperienceRepository _levelOfExperienceRepository;
        private IUserSession _userSession;
        public ProfileService()
        {
            //_profileRepository = ObjectFactory.GetInstance<IProfileRepository>();
            //_profileAttributeRepository = ObjectFactory.GetInstance<IProfileAttributeRepository>();
            //_profileAttributeService = ObjectFactory.GetInstance<IProfileAttributeService>();
            //_levelOfExperienceTypeRepository = ObjectFactory.GetInstance<ILevelOfExperienceTypeRepository>();
            //_userSession = ObjectFactory.GetInstance<IUserSession>();
            _profileRepository = new ProfileRepository();
            _profileAttributeRepository = new ProfileAttributeRepository();
            _levelOfExperienceRepository = new LevelOfExperienceRepository();
            _userSession = new UserSession();
            _profileAttributeService = new ProfileAttributeService();

        }

        public Profile LoadProfileByAccountID(Int32 AccountID)
        {
            Profile profile = _profileRepository.GetProfileByAccountID(AccountID);
            List<ProfileAttribute> attributes = new List<ProfileAttribute>();
            LevelOfExperience levelOfExperience;
            if (profile != null && profile.ProfileID > 0)
            {
                attributes = _profileAttributeService.GetProfileAttributesByProfileID(profile.ProfileID);
                //levelOfExperience = _levelOfExperienceRepository.GetLevelOfExperienceByID(profile.LevelOfExperienceID);

                profile.Attributes = attributes;
               // profile.levelOfExperience = levelOfExperience;
            }
            return profile;
        }
        public Profile LoadProfileByUserName(string UserName)
        {
            Profile profile = _profileRepository.GetProfileByUserName(UserName);
            List<ProfileAttribute> attributes = new List<ProfileAttribute>();
            LevelOfExperience levelOfExperience;
            if (profile != null && profile.ProfileID > 0)
            {
                attributes = _profileAttributeService.GetProfileAttributesByProfileID(profile.ProfileID);
               // levelOfExperience = _levelOfExperienceRepository.GetLevelOfExperienceByID(profile.LevelOfExperienceID);

                profile.Attributes = attributes;
              //  profile.levelOfExperience = levelOfExperience;
            }
            return profile;
        }
        // luu lai profile trong do bao gom luu Profile, luu cac thuoc tinh Profile và luu vao session
        public void SaveProfile(Profile profile)
        {
            Int32 profileID;
            profileID = _profileRepository.SaveProfile(profile);
            foreach (ProfileAttribute attribute in profile.Attributes)
            {
                attribute.ProfileID = profileID;
                _profileAttributeRepository.SaveProfileAttribute(attribute);
            }
            _userSession.CurrentProfile = LoadProfileByAccountID(_userSession.CurrentUser.AccountID);
            _userSession.CurrentUser.Profile = LoadProfileByAccountID(_userSession.CurrentUser.AccountID);
        }
        public void SaveProfileTable(Profile profile)
        {
            _profileRepository.SaveProfile(profile);
        }


        public Profile GetProfileByProfileID(int proID)
        {
            return _profileRepository.GetProfileByProfileID(proID);
        }
    }
}
