using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPKTWeb.Accounts.Interface
{
    public interface IRegister
    {
        void ShowErrorMessage(string Message);

        void LoadMessageCheckUserName(string Message);
        void LoadEmailAddressFromFriendInvitation(string Email);

        void LoadMessagePassWord(string Message);
        void LoadMessagePassWordLength(string Message);
    }
}