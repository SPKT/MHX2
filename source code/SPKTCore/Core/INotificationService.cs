using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core
{
    public interface INotificationService
    {
        int UnRead(int AccountID);
        List<Notification> GetNotify(int AccountID, int n);
        List<Notification> GetAllNotify(int AccountID);
    }
}
