using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface IAccountFileShareRepository
    {
        //List<AccountFileShare> GetFolderByAccountShare(Account acount, Account accountby);
        List<File> GetFolderByAccountShared(Int32 accountID);
        AccountFileShare GetFileByID(Int64 id);
        void Save(AccountFileShare acFolder);
        void Delete(AccountFileShare acFolder);
    }
}
