using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Impl;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess.Impl
{
    public class FileRepository : IFileRepository
    {
        public long fileid;
        public void setfileid(long id)
        {
            fileid = id;
        }
        public long Fileid
        {
            get { return fileid; }
            set { fileid = value; }
        }
        private Connection conn;
        private IWebContext _webContext;
        public FileRepository()
        {
            _webContext =new WebContext();
            conn = new Connection();
        }

        public File GetFileByID(Int64 FileID)
        {
            File file;
            using (SPKTDataContext dc = conn.GetContext())
            {
                file = dc.Files.Where(f => f.FileID == FileID).FirstOrDefault();
                if (file != null)
                {
                    var fileType = dc.FileTypes.Where(ft => ft.FileTypeID == file.FileTypeID).FirstOrDefault();
                    file.Extension = fileType.Name;
                }
            }
            return file;
        }

        public File GetFileByFileSystemName(Guid FileSystemName)
        {
            File file;
            using (SPKTDataContext dc = conn.GetContext())
            {
                file = dc.Files.Where(f => f.FileSystemName == FileSystemName).FirstOrDefault();
                var fileType = dc.FileTypes.Where(ft => ft.FileTypeID == file.FileTypeID).FirstOrDefault();
                file.Extension = fileType.Name;
            }
            return file;
        }
        public List<File> GetFilesByAccountID(int accountid)
        {
            List<File> result = new List<File>();
            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<File> files1 = (from f in dc.Files where f.AccountID == accountid && f.DefaultFolderID==10 select f);
                result = files1.ToList();
            }
            return result;
        }
       
        public List<File> GetFilesByFolderID1(Int64 FolderID)
        {
            List<File> result = new List<File>();
            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<File> files1 = (from f in dc.Files
                                            where f.DefaultFolderID == FolderID
                                            select f);
                result = files1.ToList();
            }
            return result;
        }
        public List<File> GetFilesByFolderID(Int64 FolderID)
        {
            List<File> result = new List<File>();
            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<File> files1 = (from f in dc.Files
                                            where f.DefaultFolderID == FolderID &&
                                                 dc.IsFlagged(5, f.FileID) != true
                                            select f);
                IEnumerable<File> files2 = (from f in dc.Files
                                            join ff in dc.FolderFiles on f.FileID equals ff.FileID
                                            where ff.FolderID == FolderID &&
                                                dc.IsFlagged(5, f.FileID) != true
                                            select f);
                IEnumerable<File> files3 = files1.Union(files2);
                result = files3.ToList();

                foreach (File file in result)
                {
                    var fileType = dc.FileTypes.Where(ft => ft.FileTypeID == file.FileTypeID).FirstOrDefault();
                    file.Extension = fileType.Name;
                }
            }

            return result;
        }

        public void UpdateDescriptions(Dictionary<int, string> fileDescriptions)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                List<Int64> fileIDs = fileDescriptions.Select(f => Convert.ToInt64(f.Key)).Distinct().ToList();
                IEnumerable<File> files = dc.Files.Where(f => fileIDs.Contains(f.FileID));
                foreach (File file in files)
                {
                    file.Description = fileDescriptions.Where(f => f.Key == file.FileID).Select(f => f.Value).ToString();
                }
                dc.SubmitChanges();
            }
        }

        public Int64 SaveFile(File file)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                if (file.FileID > 0)
                {
                    dc.Files.Attach(file, true);
                }
                else
                {
                    file.CreateDate = DateTime.Now;
                    dc.Files.InsertOnSubmit(file);
                }
                dc.SubmitChanges();
            }
            return file.FileID;
        }
        public void Save(File file)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                if (file.FileID > 0)
                {
                    dc.Files.Attach(file, true);
                }
                else
                {
                    file.CreateDate = DateTime.Now;
                    dc.Files.InsertOnSubmit(file);
                }
                dc.SubmitChanges();
            }
        }
        public void DeleteFilesInFolder(Folder folder)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                List<File> files = GetFilesByFolderID(folder.FolderID);
                foreach (File file in files)
                {
                    DeleteFileFromFileSystem(folder, file);
                }
                dc.Files.AttachAll(files, true);
                dc.Files.DeleteAllOnSubmit(files);
                dc.SubmitChanges();
            }
        }

        public void DeleteFile(File file)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                Folder folder = dc.Folders.Where(f => f.FolderID == file.DefaultFolderID).FirstOrDefault();
                DeleteFileFromFileSystem(folder, file);
                dc.Files.Attach(file, true);
                dc.Files.DeleteOnSubmit(file);
                dc.SubmitChanges();
            }
        }

        private void DeleteFileFromFileSystem(Folder folder, File file)
        {
            string path = "";
            switch (file.FileTypeID)
            {
                case 1:
                case 2:
                case 7:
                    path = "Photos\\";
                    break;
                case 3:
                case 4:
                    path = "Audios\\";
                    break;
                case 5:
                case 8:
                case 6:
                    path = "Videos\\";
                    break;
            }

            string fullPath = _webContext.FilePath + "Files\\" + path + folder.CreateDate.Year.ToString() + folder.CreateDate.Month.ToString() + "\\";

            if (System.IO.Directory.Exists(fullPath))
            {
                if (System.IO.File.Exists(fullPath + file.FileSystemName + "__o." + file.Extension))
                    System.IO.File.Delete(fullPath + file.FileSystemName + "__o." + file.Extension);
                if (System.IO.File.Exists(fullPath + file.FileSystemName + "__t." + file.Extension))
                    System.IO.File.Delete(fullPath + file.FileSystemName + "__t." + file.Extension);
                if (System.IO.File.Exists(fullPath + file.FileSystemName + "__s." + file.Extension))
                    System.IO.File.Delete(fullPath + file.FileSystemName + "__s." + file.Extension);
                if (System.IO.File.Exists(fullPath + file.FileSystemName + "__m." + file.Extension))
                    System.IO.File.Delete(fullPath + file.FileSystemName + "__m." + file.Extension);
                if (System.IO.File.Exists(fullPath + file.FileSystemName + "__l." + file.Extension))
                    System.IO.File.Delete(fullPath + file.FileSystemName + "__l." + file.Extension);

                if (System.IO.Directory.GetFiles(fullPath).Count() == 0)
                    System.IO.Directory.Delete(fullPath);
            }
        }
    }
}
