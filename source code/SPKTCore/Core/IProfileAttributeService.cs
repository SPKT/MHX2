using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core
{
    public interface IProfileAttributeService
    {
        List<ProfileAttribute> GetProfileAttributesByProfileID(Int32 ProfileID);
        List<ProfileAttributeType> GetProfileAttributeType();
        void SaveProfileAttribute(ProfileAttribute profileAttribute);
        ProfileAttribute GetProfileAttributesByProfileIDAndTypeID(Profile profile, ProfileAttributeType type);
    }
}
