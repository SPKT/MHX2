using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;

namespace SPKTCore.Core.Domain
{
    public partial class Alert
    {
        IAccountRepository _repository;
        public String SenderName
        {
            get
            {
                _repository = new AccountRepository();
                return _repository.GetAccountByID(this.AccountID).UserName;
            }
        }
    }
}
