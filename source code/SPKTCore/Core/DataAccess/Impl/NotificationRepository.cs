using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess.Impl
{
    public class NotificationRepository:INotificationRepository
    {
        private Connection conn;
        public NotificationRepository()
        {
            conn = new Connection();
        }
        public List<Notification> GetNotificationByAccountID(int AccountID, int n)
        {
            List<Notification> result = new List<Notification>();
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                IEnumerable<Notification> notify = (from a in spktDC.Notifications
                                                    where a.AccountID == AccountID
                                                    orderby a.CreateDate descending
                                                    select a).Take(n);
                result = notify.ToList();
            }
            return result;
        }
        public List<Notification> GetAllNotificationByAccountID(int AccountID)
        {
            List<Notification> result = new List<Notification>();
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                IEnumerable<Notification> notify = (from a in spktDC.Notifications
                                                    where a.AccountID == AccountID
                                                    orderby a.CreateDate descending
                                                    select a);
                result = notify.ToList();
            }
            return result;
        }



        public void SaveNotification(Notification notify)
        {
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                if (notify.NotificationID > 0)
                {
                    spktDC.Notifications.Attach(notify, true);
                }
                else
                {
                    notify.CreateDate = DateTime.Now;
                    spktDC.Notifications.InsertOnSubmit(notify);
                }
                spktDC.SubmitChanges();
            }
        }

        public void DeleteNotification(Notification notify)
        {
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                spktDC.Notifications.DeleteOnSubmit(notify);
                spktDC.SubmitChanges();
            }
        }
    }
}
