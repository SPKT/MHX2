using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface IMessageFolderRepository
    {
        MessageFolder GetMessageFolderByID(Int32 MessageFolderID);
        List<MessageFolder> GetMessageFoldersByAccountID(Int32 AccountID);
        void SaveMessageFolder(MessageFolder messageFolder);
        void DeleteMessageFolder(MessageFolder messageFolder);
    }
}
