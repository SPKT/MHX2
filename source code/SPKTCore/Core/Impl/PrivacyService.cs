using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;

namespace SPKTCore.Core.Impl
{
   public class PrivacyService:IPrivacyService
    {
       IFriendService _friendService;
       IPrivacyRepository _privacyRepository;
       IProfileRepository _profileRepository;
        public PrivacyService()
        {
            _friendService = new FriendService();
            _privacyRepository = new PrivacyRepository();
            _profileRepository = new ProfileRepository();
        }
        public bool ShouldShow(Int32 PrivacyFlagTypeID,
        Account AccountBeingViewed,
        Account Account,
        List<PrivacyFlag> Flags)
        {
            bool result;
            if (Account.AccountID == AccountBeingViewed.AccountID)
                return true;
            bool isFriend = _friendService.IsFriend(Account, AccountBeingViewed);
            if (Flags.Where(f => f.PrivacyFlagTypeID == PrivacyFlagTypeID && f.VisibilityLevelID == (int)VisibilityLevel.VisibilityLevels.Private).FirstOrDefault() != null)
                result = false;
            
            else if (Flags.Where(f => f.PrivacyFlagTypeID == PrivacyFlagTypeID && f.VisibilityLevelID == (int)VisibilityLevel.VisibilityLevels.Friends).FirstOrDefault() != null && isFriend)
                result = true;
            else if (Flags.Where(f => f.PrivacyFlagTypeID == PrivacyFlagTypeID && f.VisibilityLevelID == (int)VisibilityLevel.VisibilityLevels.Public).FirstOrDefault() != null)
                result = true;
            else
                result = false;

            return result;
        }

        public List<PrivacyFlagType> GetListPrivacyFlagType(Account Account, Account AccountBeingViewed)
        {
            List<PrivacyFlagType> listPrivacyFlagTypeSelect = new List<PrivacyFlagType>();
            List<PrivacyFlagType> listPrivacyFlagType = _privacyRepository.GetPrivacyFlagTypes();
            List<PrivacyFlag> listPrivacyFlag=_privacyRepository.GetPrivacyFlagsByProfileID(_profileRepository.GetProfileByAccountID(AccountBeingViewed.AccountID).ProfileID);
            foreach (PrivacyFlagType priFlagType in listPrivacyFlagType)
            {
                if (ShouldShow(priFlagType.PrivacyFlagTypeID, AccountBeingViewed, Account, listPrivacyFlag))
                    listPrivacyFlagType.Add(priFlagType);
            }
            return listPrivacyFlagType;

        }
        public List<PrivacyFlag> GetListPrivacyFlag(int ProfileID)
        {
            return _privacyRepository.GetPrivacyFlagsByProfileID(ProfileID);
        }




        public List<VisibilityLevel> GetListVisibilityLevel()
        {
            return _privacyRepository.GetVisibilityLevels();
        }
        public bool ShouldShowStatus(StatusUpdate Status, Account AccountBeingViewed, Account Account)
        {
            bool result;
            if (Account != null)
            {
                if (Account.AccountID == AccountBeingViewed.AccountID)
                    return true;
                bool isFriend = _friendService.IsFriend(Account, AccountBeingViewed);
                if (Status.VisibilityLevelID == (int)VisibilityLevel.VisibilityLevels.Private)
                    result = false;

                else if ((Status.VisibilityLevelID == (int)VisibilityLevel.VisibilityLevels.Friends) && (isFriend))
                    result = true;
                else if (Status.VisibilityLevelID == (int)VisibilityLevel.VisibilityLevels.Public)
                    result = true;
                else
                    result = false;

                return result;
            }
            else
            {
                if (Status.VisibilityLevelID == (int)VisibilityLevel.VisibilityLevels.Public)
                    result = true;
                else
                    result = false;
                return result;
            }
        }

    }
}
