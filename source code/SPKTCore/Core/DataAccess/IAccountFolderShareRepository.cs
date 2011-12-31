using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface IAccountFolderShareRepository
    {
        //AccountFolderShare GetFolderByAccountShare(Account acount, Account accountby);
        List<Folder> GetFolderByAccountShared(Int32 accountID);
        AccountFolderShare GetFolderByID(Int64 id);
        void Save(AccountFolderShare acFolder);
        void Delete(AccountFolderShare acFolder);
    }
}
