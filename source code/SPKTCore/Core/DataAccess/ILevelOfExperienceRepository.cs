using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface ILevelOfExperienceRepository
    {
        List<LevelOfExperience> GetAllLevelOfExperience();
        LevelOfExperience GetLevelOfExperienceByID(int LevelOfExperienceID);
        void SaveLevelOfExperience(LevelOfExperience levelOfExperience);
        void DeleteLevelOfExperience(LevelOfExperience levelOfExperience);
    }
}
