using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Impl;
using SPKTCore.Core.DataAccess.Impl;
using SPKTWeb.Photo.Interface;

namespace SPKTWeb.Photo.Presenter
{
    public class AddFile
    {
        long idAb;
        UserSession _usersession;
        WebContext _webcontext;
        FileService _fi;
        public void Init()
        {
            _usersession = new UserSession();
            _webcontext = new WebContext();
            _fi = new FileService();
        }
       
        public long addfile(Int32 FileTypeID,Int64 AlbumID, HttpPostedFile file)
        {
            if(file.ContentLength > 0)
            {
               List<Int64> fileIDs= _fi.UploadPhotos(FileTypeID, _usersession.CurrentUser.AccountID, _webcontext.Files, AlbumID);
               if (fileIDs.Count == 1)
                   return fileIDs[0];
            }
            return 0;
        }

    }
}