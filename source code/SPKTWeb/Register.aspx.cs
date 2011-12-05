using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Domain;

namespace SPKTWeb
{
    public partial class Register : System.Web.UI.Page
    {
        IAccountRepository _accountRepository;
        protected void Page_Load(object sender, EventArgs e)
        {
            _accountRepository = new AccountRepository();
        }
        protected void Username_Changed(object sender, EventArgs e)
        {
           // CustomMembershipProvider cus = new CustomMembershipProvider();
            Account acc = _accountRepository.GetAccountByUsername(Username.Text);
            if (acc != null)
            {
                UserAvailability.InnerText = "Username taken, sorry.";
                UserAvailability.Attributes.Add("class", "taken");
            }
            else
            {
                UserAvailability.InnerText = "Username available!";
                UserAvailability.Attributes.Add("class", "available");
            }

        }
    }
}