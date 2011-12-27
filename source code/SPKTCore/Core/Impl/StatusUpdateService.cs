using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;

namespace SPKTCore.Core.Impl
{
    public class StatusUpdateService:IStatusUpdateService
    {
        IStatusUpdateRepository _statusRepository;
        IAlertService _alertService;
        IPrivacyService _privacyService;
        public StatusUpdateService()
        {
            _statusRepository = new StatusUpdateRepository();
            _alertService = new AlertService();
            _privacyService = new PrivacyService();
            
        }
        public void SaveStatusUpdate(StatusUpdate statusUpdate)
        {
            _statusRepository.SaveStatusUpdate(statusUpdate);
           // if(statusUpdate.SenderID!=statusUpdate.AccountID)
            _alertService.AddStatusUpdateAlert(statusUpdate);
        }
        public List<StatusUpdate> GetStatusUpdateByID(Account Account, Account AccountBeingViewer, bool IsSender)
        {
            List<StatusUpdate> listStatus = new List<StatusUpdate>();
            List<StatusUpdate> Status=new List<StatusUpdate>();
            if (IsSender)
            {
                Status = _statusRepository.GetStatusUpdatesBySenderID(AccountBeingViewer.AccountID);

            }
            else
            {
                Status = _statusRepository.GetStatusUpdatesByAccountID(AccountBeingViewer.AccountID);
            }
            foreach (StatusUpdate status in Status)
            {
                    if (_privacyService.ShouldShowStatus(status, AccountBeingViewer, Account))
                        listStatus.Add(status);
            }
            
            return listStatus;
                
        }
    }
}
