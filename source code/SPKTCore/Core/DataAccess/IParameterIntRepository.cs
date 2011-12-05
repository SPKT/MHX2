using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPKTCore.Core.DataAccess
{
    public interface IParameterIntRepository
    {
         int GetParameterByName(string Name);
    }
}
