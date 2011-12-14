using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core
{
    public interface IAlertService
    {
        void AddAccountCreatedAlert();
        void AddAccountModifiedAlert();
        void AddProfileCreatedAlert();
        void AddProfileModifiedAlert();
        void AddNewAvatarAlert();
        void AddStatusUpdateAlert(StatusUpdate statusUpdate);
        List< Alert> GetAlertsByAccountID(Int32 AccountID);
        List<Alert> GetAlerts(int viewerID, Int32 AccountID);
        void AddNewBoardPostAlert(BoardCategory category, BoardForum forum, BoardPost post, BoardPost thread);
        void AddNewBoardThreadAlert(BoardCategory category, BoardForum forum, BoardPost post);
        void AddNewBoardThreadAlert(BoardCategory category, BoardForum forum, BoardPost post, Group group);
        void AddNewBoardPostAlert(BoardCategory category, BoardForum forum, BoardPost post, BoardPost thread,
                                  Group group);
    }
}
