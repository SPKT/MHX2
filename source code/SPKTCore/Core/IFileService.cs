using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core
{
    public interface IFileService
    {
        string GetFullFilePathByFileID(Int64 FileID, File.Sizes FileSize);
        List<Int64> UploadPhotos(Int32 FileTypeID, Int32 AccountID, HttpFileCollection Files, Int64 AlbumID);
    }
}
