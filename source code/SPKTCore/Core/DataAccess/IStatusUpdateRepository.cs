using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface IStatusUpdateRepository
    {
        List<StatusUpdate> GetTopNStatusUpdateByAccountID(Int32 AccountID, Int32 Number);
        StatusUpdate GetStatusUpdateByID(Int32 StatusUpdateID);
        List<StatusUpdate> GetStatusUpdatesByAccountID(Int32 AccountID);
        List<StatusUpdate> GetStatusUpdatesBySenderID(Int32 AccountID);

        void SaveStatusUpdate(StatusUpdate statusUpdate);
    }
}
