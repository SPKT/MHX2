using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Photo.Interface
{
    public interface IFolderShare
    {
        void LoadFolder(List<Folder> folders);
    }
}