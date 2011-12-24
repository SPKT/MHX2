using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core
{
    public interface IPermissionContent
    {
        //public bool HasViewPermission { get; }
        //public bool HasEditPermission { get; }
        //public bool HasDeletePermission { get; }
        //public bool HasCreatePermission { get; }
        PermissionType UserPermission { get; }
    }
}
