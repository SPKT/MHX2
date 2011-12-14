using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface IFileRepository
    {
        File GetFileByID(Int64 FileID);
        File GetFileByFileSystemName(Guid FileSystemName);
        Int64 SaveFile(File file);
        void DeleteFile(File file);
        List<File> GetFilesByFolderID(Int64 FolderID);
        void UpdateDescriptions(Dictionary<int, string> fileDescriptions);
        void DeleteFilesInFolder(Folder folder);
    }
}
