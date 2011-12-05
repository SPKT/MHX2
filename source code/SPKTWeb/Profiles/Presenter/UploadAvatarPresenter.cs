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
using SPKTWeb.Profiles.Interface;

namespace SPKTWeb.Profiles.Presenter
{
    public class UploadAvatarPresenter
    {
        private IProfileRepository _profileRepository;
        private IUserSession _userSession;
        private IRedirector _redirector;
        private Profile profile;
        private IUploadAvatar _view;
        private IAlertService _alertService;
        public UploadAvatarPresenter()
        {
            _userSession =new UserSession();
            _profileRepository = new ProfileRepository();
            _redirector = new Redirector();
            _alertService = new AlertService();
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

        public void UploadFile(HttpPostedFile File)
        {
            string extension = Path.GetExtension(File.FileName).ToLower();
            string mimetype;
            byte[] uploadedImage = new byte[File.InputStream.Length];
            switch (extension)
            {
                case ".png":
                case ".jpg":
                case ".gif":
                    mimetype = File.ContentType;
                    break;

                default:
                //    _view.ShowMessage("We only accept .png, .jpg, and .gif!");
                    return;
            }

            if (File.ContentLength / 1000 < 3000)
            {
                File.InputStream.Read(uploadedImage, 0, uploadedImage.Length);
                profile.Avatar = uploadedImage;
                profile.AvatarMimeType = mimetype;
                profile.UseGrAvatar= 0;
                _profileRepository.SaveProfile(profile);
                _view.ShowCropPanel();

            }
            else
            {
                _view.ShowMessage("Ảnh của bạn quá lớn!");
            }
        }
    }
}