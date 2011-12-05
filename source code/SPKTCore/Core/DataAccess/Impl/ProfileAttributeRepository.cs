using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess.Impl
{
    public class ProfileAttributeRepository:IProfileAttributeRepository
    {
        private Connection conn;
        public ProfileAttributeRepository()
        {
            conn = new Connection();
        }

        public ProfileAttributeType GetProfileAttributeTypeByID(Int32 profileAttributeTypeID)
        {
            ProfileAttributeType result;
            using (SPKTDataContext spktspktDC = conn.GetContext())
            {
                result = spktspktDC.ProfileAttributeTypes.Where(pat => pat.ProfileAttributeTypeID == profileAttributeTypeID).FirstOrDefault();
            }
            return result;
        }

        public List<ProfileAttributeType> GetProfileAttributeTypes()
        {
            List<ProfileAttributeType> list = new List<ProfileAttributeType>();
            using (SPKTDataContext spktspktDC = conn.GetContext())
            {
                var result = from t in spktspktDC.ProfileAttributeTypes
                                                          orderby t.SortOrder
                                                          select t;
                foreach (ProfileAttributeType p in result)
                {
                    list.Add(p);
                }
            }
            return list;
        }

        public void AddProfileAttributes(params ProfileAttribute[] attributes)
        {
            foreach (ProfileAttribute attribute in attributes)
            {
                SaveProfileAttribute(attribute);
            }
        }

        public void SaveProfileAttribute(ProfileAttribute attribute)
        {
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                if (attribute.ProfileAttributeID > 0)
                {
                    spktDC.ProfileAttributes.Attach(attribute, true);
                }
                else
                {
                    attribute.CreateDate = DateTime.Now;
                    spktDC.ProfileAttributes.InsertOnSubmit(attribute);
                }
                spktDC.SubmitChanges();
            }
        }

        public List<ProfileAttribute> GetProfileAttributesByProfileID(Int32 ProfileID)
        {
            List<ProfileAttribute> list = new List<ProfileAttribute>();

            using (SPKTDataContext spktDC = conn.GetContext())
            {
                var result = from pa in spktDC.ProfileAttributes
                                                       join pat in spktDC.ProfileAttributeTypes
                                                       on pa.ProfileAttributeTypeID equals pat.ProfileAttributeTypeID
                                                       orderby pat.SortOrder
                                                       where pa.ProfileID == ProfileID
                                                       select pa;
                foreach (ProfileAttribute p in result)
                    list.Add(p);
            }

            return list;
        }
        public ProfileAttribute GetProfileAttributesByProfileIDAndTypeID(Int32 ProfileID, Int32 TypeID)
        {
            ProfileAttribute attribute;

            using (SPKTDataContext spktDC = conn.GetContext())
            {
                attribute = (from t in spktDC.ProfileAttributes
                             where t.ProfileID == ProfileID && t.ProfileAttributeTypeID == TypeID
                             select t).FirstOrDefault();
               
            }
            return attribute;
        }
        //lay attribubte theo ProfileID va typeID
        public List<ProfileAttribute> GetProfileAttributesByProfileIDAndType(Int32 ProfileID, Int32 TypeID)
        {
            List<ProfileAttribute> list = new List<ProfileAttribute>();

            using (SPKTDataContext spktDC = conn.GetContext())
            {
                var ds = from t in spktDC.ProfileAttributes
                         where t.ProfileID == ProfileID && t.ProfileAttributeTypeID == TypeID
                         select t;
                foreach (ProfileAttribute p in ds)
                    list.Add(p);
            }
            return list;
        }
    }
}
