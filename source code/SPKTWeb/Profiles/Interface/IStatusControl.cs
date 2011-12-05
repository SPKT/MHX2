using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Profiles.Interface
{
    public interface IStatusControl
    {
        void LoadRange(List<VisibilityLevel> visiLevel);
    }
}
