using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess.Impl
{
    class Connection
    {
         static String _ConnectionString;
         public static String ConnectionString
         {
             get {
                 if (_ConnectionString == null)
                     _ConnectionString = SPKTCore.Properties.Settings.Default.SPKTConnectionString1;
                 return _ConnectionString; }
             set
             {
                 _ConnectionString = value;
             }
         }
        public SPKTDataContext GetContext()
        {
            SPKTDataContext spktDC = new SPKTDataContext(ConnectionString);
            spktDC.DeferredLoadingEnabled = false;
            return spktDC;
        }
    }
}
