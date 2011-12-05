using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.DataAccess;

namespace SPKTCore.Core.Impl
{
    public class ParameterIntService:IParameterIntService
    {
        IParameterIntRepository _parameterIntRepository;
        public ParameterIntService()
        {
            _parameterIntRepository = new ParameterIntRepository();
        }
        public int GetParameterIntByName(string Name)
        {
           return _parameterIntRepository.GetParameterByName(Name);
        }
    }
}
