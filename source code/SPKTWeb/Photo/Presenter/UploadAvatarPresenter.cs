using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core;
using SPKTCore.Core.Domain;
using SPKTCore.Core.Impl;
using SPKTCore.Core.DataAccess.Impl;
using System.IO;
using System.Drawing;
using SPKTWeb.Photo.Interface;

namespace SPKTWeb.Photo.Presenter
{
    public class UploadAvatarPresenter
    {
        private IProfileRepository _profileRepository;
        private IUserSession _userSession;
        private IRedirector _redirector;
        private Profile profile;
        private IUploadAvatar _view;
        private IAlertService _alertService;
        IWebContext _webcontext;
        FolderRepository _for;
        public UploadAvatarPresenter()
        {
            _userSession =new UserSession();
            _profileRepository = new ProfileRepository();
            _redirector = new Redirector();
            _alertService = new AlertService();
            _webcontext = new WebContext();
            _for = new FolderRepository();
        }

        public void Init(IUploadAvatar View)
        {
            _view = View;
            if (_userSession.LoggedIn)
            {
                profile = _profileRepository.GetProfileByAccountID(_userSession.CurrentUser.AccountID);
                if (profile == null || profile.ProfileID < 1)
                    _redirector.GoToAccountLoginPage();
            }
            else
                _redirector.GoToAccountLoginPage();
        }

        public void UseGravatar()
        {
            profile.UseGrAvatar = 1;
            _profileRepository.SaveProfile(profile);
            _alertService.AddNewAvatarAlert();
            _redirector.GoToProfilesProfile();
        }

        public void StartNewAvatar()
        {
            _view.ShowUploadPanel();
        }

        public void Complete()
        {
            _alertService.AddNewAvatarAlert();
            _redirector.GoToProfilesProfile();
        }

        public void CropFile(Int32 X, Int32 Y, Int32 Width, Int32 Height)
        {
            //get byte array from profile
            byte[] imageBytes = profile.Avatar.ToArray();
            //stuff this byte array into a memory stream
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                //write the memory stream out for use
                ms.Write(imageBytes, 0, imageBytes.Length);

                //stuff the memory stream into an image to work with
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms, true);
                int originWidth = img.Width;
                int originHeight = img.Height;
                X = (X * originWidth) / 500;
                Y = (Y * originHeight) / 350;
                Width = (Width * originWidth) / 500;
                Height = (Height * originHeight) / 350;

                //create the destination (cropped) bitmap
                Bitmap bmpCropped = new Bitmap(200, 200);

                //create the graphics object to draw with
                Graphics g = Graphics.FromImage(bmpCropped);

                Rectangle rectDestination = new Rectangle(0, 0, bmpCropped.Width, bmpCropped.Height);
                Rectangle rectCropArea = new Rectangle(X, Y, Width, Height);

                //draw the rectCropArea of the original image to the rectDestination of bmpCropped
                g.DrawImage(img, rectDestination, rectCropArea, GraphicsUnit.Pixel);

                //release system resources
                g.Dispose();

                MemoryStream stream = new MemoryStream();
                bmpCropped.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] bytes = stream.ToArray();

                profile.Avatar = bytes;
                _profileRepository.SaveProfile(profile);
            }
            _view.ShowApprovePanel();
        }

        public void UploadFile(HttpPostedFile file,string desc, bool Ispublic)
        {
            string extension = Path.GetExtension(file.FileName).ToLower();
            string mimetype;
            byte[] uploadedImage = new byte[file.InputStream.Length];
            switch (extension)
            {
                case ".png":
                case ".jpg":
                case ".gif":
                    mimetype = file.ContentType;
                    break;

                default:
                //    _view.ShowMessage("We only accept .png, .jpg, and .gif!");
                    return;
            }

            if (file.ContentLength / 1000 < 3000)
            {
                SPKTCore.Core.Domain.File fi = new SPKTCore.Core.Domain.File();
                fi.AccountID = _userSession.CurrentUser.AccountID;
                fi.CreateDate = DateTime.Now;
                if (_webcontext.FolderID > 1)
                {
                    fi.DefaultFolderID = _webcontext.FolderID;
                   
                }
                else
                {
                    fi.DefaultFolderID = 10;
                }
                fi.Description = desc;
                fi.FileName = file.FileName;
                fi.FileSystemFolderID = 1;
                Guid guiname = Guid.NewGuid();
                fi.FileSystemName = guiname;
                string fileType="1";
                switch (fileType)
                {
                    case "1":
                        fi.FileSystemFolderID = (int)FileSystemFolder.Paths.Pictures;
                        switch (extension.ToLower())
                        {
                            case "jpg":
                                fi.FileTypeID = (int)SPKTCore.Core.Domain.File.Types.JPG;
                                break;
                            case "gif":
                                fi.FileTypeID = (int)SPKTCore.Core.Domain.File.Types.GIF;
                                break;
                            case "jpeg":
                                fi.FileTypeID = (int)SPKTCore.Core.Domain.File.Types.JPEG;
                                break;
                            default:
                                fi.FileTypeID = 1;
                                break;
                        }
                        break;

                    case "2":
                        fi.FileSystemFolderID = (int)FileSystemFolder.Paths.Videos;
                        switch (extension.ToLower())
                        {
                            case "wmv":
                                fi.FileTypeID = (int)SPKTCore.Core.Domain.File.Types.WMV;
                                break;
                            case "flv":
                                fi.FileTypeID = (int)SPKTCore.Core.Domain.File.Types.FLV;
                                break;
                            case "swf":
                                fi.FileTypeID = (int)SPKTCore.Core.Domain.File.Types.SWF;
                                break;
                            default:
                                fi.FileTypeID=4;
                                break;
                        }
                        break;

                    
                }
                fi.FileTypeID = int.Parse(fileType);
                fi.IsPublicResource = Ispublic;
                fi.Size = file.ContentLength;
                file.InputStream.Read(uploadedImage, 0, uploadedImage.Length);
                fi.ContentFile = uploadedImage;
                FileRepository fr = new FileRepository();
                fr.Save(fi);
                Folder fo = _for.GetFolderByID(fi.DefaultFolderID);
                fo.FileDescID = fi.FileID;
                _for.SaveFolder(fo);
                if (_webcontext.FolderID == 1)
                {
                    UserSession _usersession = new UserSession();
                    StatusUpdate st = new StatusUpdate();
                    StatusUpdateRepository s = new StatusUpdateRepository();
                    st.AccountID = _usersession.CurrentUser.AccountID;
                    st.VisibilityLevelID = 1;
                    st.Status = "Tạo Ảnh mới" + fi.FileName;
                    st.SenderID = _usersession.CurrentUser.AccountID;
                    st.FileID = fi.FileID;
                    s.SaveStatusUpdate(st);
                }
            }
            else
            {
               // _view.ShowMessage("Ảnh của bạn quá lớn!");
            }
        }
    }
}