using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface IAlertRepository
    {
        List<Alert> GetAlertsByAccountID(Int32 AccountID);
        void SaveAlert(Alert alert);
        void DeleteAlert(Alert alert);
    }
}
