using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPKTWeb.Accounts.Interface
{
    public interface IEditAccount
    {
        void ShowMessage(string Message);
        void LoadCurrentInformation(SPKTCore.Core.Domain.Account account);
        void ShowErrorSavePass(string Message);

        void ShowErrorSaveEmail(string Message);
    }
}