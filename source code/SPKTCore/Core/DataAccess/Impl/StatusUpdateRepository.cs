using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess.Impl
{
    public class StatusUpdateRepository:IStatusUpdateRepository
    {
        Connection conn;
        public StatusUpdateRepository()
        {
            conn = new Connection();
        }
        public StatusUpdate GetStatusUpdateByID(Int32 StatusUpdateID)
        {
            StatusUpdate result;
            using (SPKTDataContext dc = conn.GetContext())
            {
                result = dc.StatusUpdates.Where(su => su.StatusUpdateID == StatusUpdateID).FirstOrDefault();
            }
            return result;
        }

       public List<StatusUpdate> GetStatusUpdatesBySenderID(Int32 AccountID)
        {
            List<StatusUpdate> result = new List<StatusUpdate>();
            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<StatusUpdate> statusUpdates = from su in dc.StatusUpdates
                                                          where su.SenderID == AccountID
                                                          orderby su.CreateDate descending
                                                          select su;
                result = statusUpdates.ToList();
            }
            return result;
        }
       public List<StatusUpdate> GetStatusUpdatesByAccountID(Int32 AccountID)
       {
           List<StatusUpdate> result = new List<StatusUpdate>();
           using (SPKTDataContext dc = conn.GetContext())
           {
               IEnumerable<StatusUpdate> statusUpdates = from su in dc.StatusUpdates
                                                         where su.AccountID == AccountID
                                                         orderby su.CreateDate descending
                                                         select su;
               result = statusUpdates.ToList();
           }
           return result;
       }
        public void SaveStatusUpdate(StatusUpdate statusUpdate)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                if (statusUpdate.StatusUpdateID > 0)
                {
                    dc.StatusUpdates.Attach(statusUpdate, true);
                }
                else
                {
                    statusUpdate.CreateDate = DateTime.Now;
                    dc.StatusUpdates.InsertOnSubmit(statusUpdate);
                }
                dc.SubmitChanges();
            }
        }


        public List<StatusUpdate> GetTopNStatusUpdateByAccountID(int AccountID, int Number)
        {
            List<StatusUpdate> result = new List<StatusUpdate>();
            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<StatusUpdate> statusUpdates = (from su in dc.StatusUpdates
                                                           where su.SenderID == AccountID
                                                           orderby su.CreateDate descending
                                                           select su).Take(Number);
                result = statusUpdates.ToList();
            }
            return result;
        }
    }
}
