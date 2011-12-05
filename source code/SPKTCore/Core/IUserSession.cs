using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using SPKTCore.Core.Domain;


namespace SPKTCore.Core
{
    [PluginFamily("Default")]
    public interface IUserSession
    {
        bool LoggedIn { get; set; }
        string Username { get; set; }
        Account CurrentUser { get; set; }
        Profile CurrentProfile { get; set; }
    }
}
