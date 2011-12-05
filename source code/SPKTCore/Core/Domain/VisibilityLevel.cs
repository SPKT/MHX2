using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPKTCore.Core.Domain
{
    public partial class VisibilityLevel
    {
        public enum VisibilityLevels
        {
            Private = 3,
            Friends = 2,
            Public = 1
        }
    }
}
