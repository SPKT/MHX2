using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;
using SPKTCore.Core.Impl;

namespace SPKTWeb.Searchs.Interface
{
    public interface ISearch
    {
        void LoadAccounts(List<Account> Accounts);
    }
}