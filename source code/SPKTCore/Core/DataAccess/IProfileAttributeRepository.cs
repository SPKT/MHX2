using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface IProfileAttributeRepository
    {
        List<ProfileAttributeType> GetProfileAttributeTypes();
        void AddProfileAttributes(params ProfileAttribute[] attributes);
        void SaveProfileAttribute(ProfileAttribute attribute);
        List<ProfileAttribute> GetProfileAttributesByProfileID(Int32 ProfileID);
        ProfileAttributeType GetProfileAttributeTypeByID(Int32 profileAttributeTypeID);
        List<ProfileAttribute> GetProfileAttributesByProfileIDAndType(Int32 ProfileID, Int32 TypeID);
        ProfileAttribute GetProfileAttributesByProfileIDAndTypeID(Int32 ProfileID, Int32 TypeID);

    }
}
