using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Domain;
using System.Web;
using System.Drawing;


namespace SPKTCore.Core.Impl
{
    public class FileService : IFileService
    {
        public string ImageFolder = "";

        Dictionary<string, int> sizesToMake = new Dictionary<string, int>();
        private int sizeTiny = 50;
        private int sizeSmall = 200;
        private int sizeMedium = 500;
        private int sizeLarge = 1000;
        int NewWidth = 0;
        int NewHeight = 0;
        string saveToFolder = "";

        private IWebContext _webContext;
        private IFileRepository _fileRepository;
        private IAccountRepository _accountRepository;

        //private IFileRepository _fileRepository;
        private IFolderRepository _folderRepository;
        public FileService()
        {
            _fileRepository = new FileRepository();
            _folderRepository =new FolderRepository();
            _webContext = new WebContext();
            _accountRepository = new AccountRepository();
        }

        public List<Int64> UploadPhotos(Int32 FileTypeID, Int32 AccountID, HttpFileCollection Files, Int64 AlbumID)
        {
            List<Int64> result = new List<long>();
            Folder folder = _folderRepository.GetFolderByID(AlbumID);

            saveToFolder = _webContext.FilePath + "Files\\";

            sizesToMake.Add("T", sizeTiny);
            sizesToMake.Add("S", sizeSmall);
            sizesToMake.Add("M", sizeMedium);
            sizesToMake.Add("L", sizeLarge);

            switch (FileTypeID)
            {
                case 1:
                    saveToFolder += "Photos\\";
                    break;

                case 2:
                    saveToFolder += "Videos\\";
                    break;

                case 3:
                    saveToFolder += "Audios\\";
                    break;
            }

            //make sure the directory is ready for use
            saveToFolder += folder.CreateDate.Year.ToString() + folder.CreateDate.Month.ToString() + "\\";

            if (!System.IO.Directory.Exists(saveToFolder))
                System.IO.Directory.CreateDirectory(saveToFolder);

            Account account = _accountRepository.GetAccountByID(AccountID);

            HttpFileCollection uploadedFiles = Files;
            string Path = saveToFolder;
            for (int i = 0; i < uploadedFiles.Count; i++)
            {
                HttpPostedFile F = uploadedFiles[i];
                if (uploadedFiles[i] != null && F.ContentLength > 0)
                {
                    string folderID = AlbumID.ToString();
                    string fileType = "1";
                    string uploadedFileName = F.FileName.Substring(F.FileName.LastIndexOf("\\") + 1);
                    string extension = uploadedFileName.Substring(uploadedFileName.LastIndexOf(".") + 1);
                    Guid guidName = Guid.NewGuid();
                    string fullFileName = Path + "\\" + guidName.ToString() + "__O." + extension;
                    bool goodFile = true;

                    //create the file
                    File file = new File();

                    #region "Determine file type"
                    switch (fileType)
                    {
                        case "1":
                            file.FileSystemFolderID = (int)FileSystemFolder.Paths.Pictures;
                            switch (extension.ToLower())
                            {
                                case "jpg":
                                    file.FileTypeID = (int)File.Types.JPG;
                                    break;
                                case "gif":
                                    file.FileTypeID = (int)File.Types.GIF;
                                    break;
                                case "jpeg":
                                    file.FileTypeID = (int)File.Types.JPEG;
                                    break;
                                default:
                                    goodFile = false;
                                    break;
                            }
                            break;

                        case "2":
                            file.FileSystemFolderID = (int)FileSystemFolder.Paths.Videos;
                            switch (extension.ToLower())
                            {
                                case "wmv":
                                    file.FileTypeID = (int)File.Types.WMV;
                                    break;
                                case "flv":
                                    file.FileTypeID = (int)File.Types.FLV;
                                    break;
                                case "swf":
                                    file.FileTypeID = (int)File.Types.SWF;
                                    break;
                                default:
                                    goodFile = false;
                                    break;
                            }
                            break;

                        case "3":
                            file.FileSystemFolderID = (int)FileSystemFolder.Paths.Audios;
                            switch (extension.ToLower())
                            {
                                case "wav":
                                    file.FileTypeID = (int)File.Types.WAV;
                                    break;
                                case "mp3":
                                    file.FileTypeID = (int)File.Types.MP3;
                                    break;
                                case "flv":
                                    file.FileTypeID = (int)File.Types.FLV;
                                    break;
                                default:
                                    goodFile = false;
                                    break;
                            }
                            break;
                    }
                    #endregion

                    file.Size = F.ContentLength;
                    file.AccountID = account.AccountID;
                    file.DefaultFolderID = Convert.ToInt32(folderID);
                    file.FileName = uploadedFileName;
                    file.FileSystemName = guidName;
                    file.Description = "";
                    file.IsPublicResource = false;

                    if (goodFile)
                    {
                        result.Add(_fileRepository.SaveFile(file));

                        F.SaveAs(fullFileName);

                        if (Convert.ToInt32(fileType) == ((int)Folder.Types.Picture))
                        {
                            Resize(F, saveToFolder, guidName, extension);
                        }
                    }
                }
            }

            return result;
        }

        public void Resize(HttpPostedFile F, string SaveToFolder, Guid SystemFileNamePrefix, string Extension)
        {
            //Makes all the different sizes in the sizesToMake collection
            foreach (KeyValuePair<string, int> pair in sizesToMake)
            {
                using (System.Drawing.Image image = System.Drawing.Image.FromStream(F.InputStream))
                //determine the thumbnail sizes
                using (Bitmap bitmap = new Bitmap(image))
                {
                    decimal Ratio;
                    if (bitmap.Width > bitmap.Height)
                    {
                        Ratio = (decimal)pair.Value / bitmap.Width;
                        NewWidth = pair.Value;
                        decimal Temp = bitmap.Height * Ratio;
                        NewHeight = (int)Temp;
                    }
                    else
                    {
                        Ratio = (decimal)pair.Value / bitmap.Height;
                        NewHeight = pair.Value;
                        decimal Temp = bitmap.Width * Ratio;
                        NewWidth = (int)Temp;
                    }
                }

                using (System.Drawing.Image image = System.Drawing.Image.FromStream(F.InputStream))
                using (Bitmap bitmap = new Bitmap(image, NewWidth, NewHeight))
                {
                    bitmap.Save(SaveToFolder + "/" + SystemFileNamePrefix.ToString() + "__" + pair.Key + "." + Extension, image.RawFormat);
                }
            }
        }

        public string GetFullFilePathByFileID(long FileID, Domain.File.Sizes FileSize)
        {
            string result = "";
            File file = _fileRepository.GetFileByID(FileID);

            if (file != null)
            {
                Folder folder = _folderRepository.GetFolderByID(file.DefaultFolderID);
                result = folder.CreateDate.Year.ToString() + folder.CreateDate.Month.ToString() + "/" +
                                file.FileSystemName + "__" + FileSize.ToString() + "." + file.Extension;
            }
            return result;
        }
    }
}
