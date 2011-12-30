using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;

namespace SPKTCore.Core.Domain
{
    [Serializable]
    public partial class Blog
    {
        IAccountRepository _repository;
        public String AccountName
        {
            get
            {
                _repository = new AccountRepository();
                return _repository.GetAccountByID(this.AccountID).UserName;
            }
        }
    }
}
