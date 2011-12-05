using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core
{
    public interface IStatusUpdateService
    {
        void SaveStatusUpdate(StatusUpdate statusUpdate);
        List<StatusUpdate> GetStatusUpdateByID(Account Account, Account AccountBeingViewer, bool IsSender);
    }
}
