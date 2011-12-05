using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess.Impl
{
    public class AlertRepository:IAlertRepository
    {
        private Connection conn;
        public AlertRepository()
        {
            conn = new Connection();
        }

        public List<Alert> GetAlertsByAccountID(Int32 AccountID)
        {
            List<Alert> result = new List<Alert>();
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                IEnumerable<Alert> alerts = (from a in spktDC.Alerts
                                             where a.AccountID == AccountID
                                             orderby a.CreateDate descending
                                             select a).Take(40);
                result = alerts.ToList();
            }
            return result;
        }

        public void SaveAlert(Alert alert)
        {
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                if (alert.AlertID > 0)
                {
                    spktDC.Alerts.Attach(alert, true);
                }
                else
                {
                    alert.CreateDate = DateTime.Now;
                    spktDC.Alerts.InsertOnSubmit(alert);
                }
                spktDC.SubmitChanges();
            }
        }

        public void DeleteAlert(Alert alert)
        {
            using (SPKTDataContext spktDC = conn.GetContext())
            {
                spktDC.Alerts.DeleteOnSubmit(alert);
                spktDC.SubmitChanges();
            }
        }
    }
}
