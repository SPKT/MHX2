using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPKTWeb.Accounts.Interface
{
    public interface IVerifyEmail
    {
        void ShowMessage(string Message, bool YN);
    }
}