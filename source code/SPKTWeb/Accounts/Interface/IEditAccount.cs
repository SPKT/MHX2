using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPKTWeb.Accounts.Interface
{
    public interface IEditAccount
    {
        
        void LoadCurrentInformation(SPKTCore.Core.Domain.Account account);
        void ShowErrorSavePass(string Message);
        void ShowDisplayname(string Message);
        void ShowUseAuthen(string Message);
        void ShowErrorSaveEmail(string Message);

        void DisplayAuthentical(bool p);
    }
}