using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess.Impl
{
    public class LevelOfExperienceRepository:ILevelOfExperienceRepository
    {
        private Connection conn;
        public LevelOfExperienceRepository()
        {
            conn = new Connection();
        }

        public List<LevelOfExperience> GetAllLevelOfExperiences()
        {
            List<LevelOfExperience> types = new List<LevelOfExperience>();
            using(SPKTDataContext spktspktDC = conn.GetContext())
            {
                IEnumerable<LevelOfExperience> result = spktspktDC.LevelOfExperiences.OrderBy(l => l.SortOrder);
                types = result.ToList();
            }
            return types;
        }

        public LevelOfExperience GetLevelOfExperienceByID(int LevelOfExperienceID)
        {
            LevelOfExperience result;
            using(SPKTDataContext spktspktDC = conn.GetContext())
            {
                result = spktspktDC.LevelOfExperiences.Where(l => l.LevelOfExperienceID == LevelOfExperienceID).FirstOrDefault();
            }
            return result;
        }

        public void SaveLevelOfExperience(LevelOfExperience LevelOfExperience)
        {
            using(SPKTDataContext spktspktDC = conn.GetContext())
            {
                if(LevelOfExperience.LevelOfExperienceID > 0)
                {
                    spktspktDC.LevelOfExperiences.Attach(LevelOfExperience);
                }
                else
                {
                    spktspktDC.LevelOfExperiences.InsertOnSubmit(LevelOfExperience);
                }
                spktspktDC.SubmitChanges();
            }
        }

        public void DeleteLevelOfExperience(LevelOfExperience LevelOfExperience)
        {
            using(SPKTDataContext spktspktDC = conn.GetContext())
            {
                spktspktDC.LevelOfExperiences.DeleteOnSubmit(LevelOfExperience);
                spktspktDC.SubmitChanges();
            }
        }


        public List<LevelOfExperience> GetAllLevelOfExperience()
        {
            throw new NotImplementedException();
        }
    }
}
