using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;

namespace SPKTCore.Core.Domain
{
    public partial class StatusUpdate:IComparable<StatusUpdate>
    {
        IAccountRepository _repository;
        public String SenderName
        {
            get
            {
                _repository = new AccountRepository();
                return _repository.GetAccountByID(this.SenderID).UserName;
            }
        }
        public String AccountName
        {
            get
            {
                _repository = new AccountRepository();
                return _repository.GetAccountByID((int)this.AccountID).UserName;
            }
        }

        public int CompareTo(StatusUpdate st)
        {
            return this.CreateDate.CompareTo(st.CreateDate);
        }
    }
}
