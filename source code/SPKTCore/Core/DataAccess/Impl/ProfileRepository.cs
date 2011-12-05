using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using SPKTCore.Core.Domain;
using SPKTCore.Core.Impl;
using System.Data.SqlTypes;

namespace SPKTCore.Core.DataAccess.Impl
{
    [Pluggable("Default")]
    public class ProfileRepository:IProfileRepository
    {
        private Connection conn;
        private IAlertService _alertService;
        //private IConfiguration _configuration;
        public ProfileRepository()
        {
            conn = new Connection();
            _alertService = new AlertService();
        }
        public Profile GetProfileByAccountID(int AccountID)
        {
            Profile profile;

            using (SPKTDataContext spktDC = conn.GetContext())
            {
                profile = (from p in spktDC.Profiles
                           where p.AccountID == AccountID
                           select p).FirstOrDefault();
            }

            return profile;
        }

        public int SaveProfile(Profile profile)
        {
            Int32 profileID;
            profile.LastUpdateDate = DateTime.Now;
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                if (profile.ProfileID > 0)
                {
                    spktDC.Profiles.Attach(profile, true);
                    _alertService.AddProfileModifiedAlert();
                }
                else
                {
                    profile.CreateDate = DateTime.Now;
                    spktDC.Profiles.InsertOnSubmit(profile);
                   _alertService.AddProfileCreatedAlert();
                }
                spktDC.SubmitChanges();
                profileID = profile.ProfileID;
            }
            return profileID;
        }

        public void DeleteProfile(Profile profile)
        {
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                spktDC.Profiles.Attach(profile, true);
                spktDC.Profiles.DeleteOnSubmit(profile);
                spktDC.SubmitChanges();
            }
        }

        public List<Profile> GetProfilesForIndexing(int PageNumber)
        {
            List<Profile> results = new List<Profile>();
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                results = spktDC.Profiles.Skip(100 * (PageNumber - 1)).Take(100).ToList();
            }
            return results;
        }


        public Profile GetProfileByProfileID(int ProfileID)
        {
            Profile profile;

            using (SPKTDataContext spktDC = conn.GetContext())
            {
                profile = (from p in spktDC.Profiles
                           where p.ProfileID == ProfileID
                           select p).FirstOrDefault();
            }

            return profile;
        }


        public Profile GetProfileByUserName(string UserName)
        {
            Profile profile;

            using (SPKTDataContext spktDC = conn.GetContext())
            {
                profile = (from p in spktDC.Profiles
                           where p.Account.UserName == UserName
                           select p).FirstOrDefault();
            }

            return profile;
        }
    }
}
