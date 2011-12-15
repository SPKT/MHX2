using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Profiles.Interface
{
    public interface INotificationControl
    {
        void LoadData(List<Notification> notifycations);
    }
}