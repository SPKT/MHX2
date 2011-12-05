using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core
{
    public interface IProfileService
    {
        Profile LoadProfileByAccountID(Int32 AccountID);
        Profile LoadProfileByUserName(string UserName);
        void SaveProfile(Profile profile);
        void SaveProfileTable(Profile profile);

        Profile GetProfileByProfileID(int proID);
    }
}
