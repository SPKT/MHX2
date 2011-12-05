using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core
{
    public interface IPrivacyService
    {
        bool ShouldShow(Int32 PrivacyFlagTypeID,Account AccountBeingViewed,Account Account,List<PrivacyFlag> Flags);
        List<PrivacyFlagType> GetListPrivacyFlagType(Account Account, Account AccountBeingViewed);
        List<PrivacyFlag> GetListPrivacyFlag(int ProfileID);
        List<VisibilityLevel> GetListVisibilityLevel();
        bool ShouldShowStatus(StatusUpdate Status, Account AccountBeingViewed, Account Account);

    }
}
