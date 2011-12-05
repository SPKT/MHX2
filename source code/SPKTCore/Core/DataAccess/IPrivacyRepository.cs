using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface IPrivacyRepository
    {
        List<PrivacyFlagType> GetPrivacyFlagTypes();
        List<VisibilityLevel> GetVisibilityLevels();
        List<PrivacyFlag> GetPrivacyFlagsByProfileID(Int32 ProfileID);
        void SavePrivacyFlag(PrivacyFlag privacyFlag);
    }
}
