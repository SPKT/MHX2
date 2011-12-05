using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using SPKTCore.Core.Domain;
namespace SPKTCore.Core.DataAccess
{
    [PluginFamily("Defaul")]
    public interface IProfileRepository
    {
        Profile GetProfileByAccountID(int AccountID);
        Profile GetProfileByProfileID(int ProfileID);
        Profile GetProfileByUserName(string UserName);
        Int32 SaveProfile(Profile profile);
        void DeleteProfile(Profile profile);
        List<Profile> GetProfilesForIndexing(int PageNumber);

    }
}
