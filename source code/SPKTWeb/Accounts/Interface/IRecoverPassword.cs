using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPKTWeb.Accounts.Interface
{
    public interface IRecoverPassword
    {
        void ShowMessage(string Message);
        void ShowRecoverPasswordPanel(bool Value);
    }
}