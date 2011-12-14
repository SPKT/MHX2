using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess.Impl
{
    public class FileSystemFolderRepository : IFileSystemFolderRepository
    {
        private Connection _conn;
        public FileSystemFolderRepository()
        {
            _conn = new Connection();
        }

        public FileSystemFolder GetFileSystemFolderByID(Int32 FileSystemFolderID)
        {
            throw new Exception("GetFileSystemFolderByID is not implemented!");
        }

        public void SaveFileSystemFolder(FileSystemFolder FileSystemFolder)
        {
            throw new Exception("SaveFileSystemFolder is not implemented!");
        }

        public void DeleteFileSystemFolder(FileSystemFolder FileSystemFolder)
        {
            throw new Exception("DeleteFileSystemFolder is not implemented!");
        }
    }
}
