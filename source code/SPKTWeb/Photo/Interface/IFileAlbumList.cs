using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Photo.Interface
{
    public interface IFileAlbumList
    {
        void LoadFile(List<File> files);
        //void LoadFileMain(File file);
        //void LoadCountFile(int filecount);
    }
}