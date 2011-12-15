using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface INotificationRepository
    {
        List<Notification> GetNotificationByAccountID(Int32 AccountID, int n);
        List<Notification> GetAllNotificationByAccountID(Int32 AccountID);
        void SaveNotification(Notification notify);
        void DeleteNotification(Notification notify);
    }
}
