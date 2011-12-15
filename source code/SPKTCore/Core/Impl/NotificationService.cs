using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.DataAccess;

namespace SPKTCore.Core.Impl
{
    public class NotificationService: INotificationService
    {
        INotificationRepository _notificationRepository;
        public NotificationService()
        {
            _notificationRepository=new NotificationRepository();
        }



        public List<Notification> GetNotify(int AccountID, int n)
        {
             return _notificationRepository.GetNotificationByAccountID(AccountID, n);
        }

        public int UnRead(int AccountID)
        {
            List<Notification> notications = _notificationRepository.GetAllNotificationByAccountID(AccountID);
            int result=0;
            foreach (Notification note in notications)
            {
                if (note.IsRead == false)
                    result++;
            }
            return result;
        }
    }
}
