using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface IFileSystemFolderRepository
    {
        FileSystemFolder GetFileSystemFolderByID(Int32 FileSystemFolderID);
        void SaveFileSystemFolder(FileSystemFolder FileSystemFolder);
        void DeleteFileSystemFolder(FileSystemFolder FileSystemFolder);
    }
}
