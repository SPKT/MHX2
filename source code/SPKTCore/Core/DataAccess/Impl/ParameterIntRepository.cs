using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess.Impl
{
    public class ParameterIntRepository:IParameterIntRepository
    {
        private Connection conn;
        public ParameterIntRepository()
        {
            conn = new Connection();

        }
        public int GetParameterByName(string Name)
        {
            ParameterInt parameterInt;
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                 parameterInt= (from a in spktDC.ParameterInts
                            where a.ParameterName == Name
                            select a).FirstOrDefault();

            }
            return parameterInt.ParameterContent;
            
        }

    }
}
