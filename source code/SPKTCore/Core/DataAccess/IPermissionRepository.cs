using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.DataAccess.Impl;
using StructureMap;
using SPKTCore.Core.Domain;
/// <summary>
/// Summary description for IPermissionRepository
/// </summary>
namespace SPKTCore.Core.DataAccess
{
    [PluginFamily("Default")]
    public interface IPermissionRepository
    {
        List<Permission> GetPermissionsByAccountID(Int32 AccountID);
        Permission GetPermissionByName(string Name);
        Permission GetPermissionByID(Int32 PermissionID);
        void SavePermission(Permission permission);
        void DeletePermission(Permission permission);
    }
}