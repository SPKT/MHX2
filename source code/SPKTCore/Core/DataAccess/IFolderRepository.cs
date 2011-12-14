using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface IFolderRepository
    {
        Folder GetFolderByID(Int64 FolderID);
        Int64 SaveFolder(Folder folder);
        void DeleteFolder(Folder folder);
        List<Folder> GetFoldersByAccountID(Int32 AccountID);
        List<Folder> GetFriendsFolders(List<Friend> Friends);
    }
}
