using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPKTCore.Core.Domain
{
    [Flags]
    public enum PermissionType
    {
        View =0x0001,
        Create=0x0002,
        Delete=0x0004,
        Edit=0x0008
    }
}
