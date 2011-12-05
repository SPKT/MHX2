using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess.Impl;

namespace SPKTCore.Core.Impl
{
    public class ProfileAttributeService:IProfileAttributeService
    {
        private IProfileAttributeRepository _profileAttributeRepository;
        public ProfileAttributeService()
        {
           // profileAttributeRepository = ObjectFactory.GetInstance<IProfileAttributeRepository>();  
            _profileAttributeRepository=new ProfileAttributeRepository();
        }
        // lay ra list thuoc tinh cua ProfileID do
        public List<ProfileAttribute> GetProfileAttributesByProfileID(Int32 ProfileID)
        {
            List<ProfileAttribute> attributes = _profileAttributeRepository.GetProfileAttributesByProfileID(ProfileID);
            //lay kieu thuoc tinh cua tung thuoc tinh
            foreach (ProfileAttribute attribute in attributes)
            {
                attribute.ProfileAttributeType =
                    _profileAttributeRepository.GetProfileAttributeTypeByID(attribute.ProfileAttributeTypeID);
            }
            return attributes;
        }


        public List<ProfileAttributeType> GetProfileAttributeType()
        {
            return _profileAttributeRepository.GetProfileAttributeTypes();
        }


        public void SaveProfileAttribute(ProfileAttribute profileAttribute)
        {
            _profileAttributeRepository.SaveProfileAttribute(profileAttribute);
        }


        public ProfileAttribute GetProfileAttributesByProfileIDAndTypeID(Profile profile, ProfileAttributeType type)
        {
            return _profileAttributeRepository.GetProfileAttributesByProfileIDAndTypeID(profile.ProfileID, type.ProfileAttributeTypeID);
        }
    }
    
}
