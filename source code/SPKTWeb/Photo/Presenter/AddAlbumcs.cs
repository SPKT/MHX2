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
    public class AddAlbumcs
    {
        UserSession _usersession = new UserSession();
        WebContext _webcontext = new WebContext();
        FolderRepository _fi = new FolderRepository();
        IAddAlbum _ia;
       
        public void Init(IAddAlbum a)
        {
            _ia=a;

        }
        
        public long addAlbum(int AccID, string name, bool ispup, string desc, int FolderTypeID)
        {
            Folder newForder=new Folder();
            newForder.AccountID=AccID;
            newForder.CreateDate=DateTime.Now;
            newForder.Description=desc;
            newForder.FolderTypeID=FolderTypeID;
            newForder.Location="location";
            newForder.Name=name;
            newForder.IsPublicResource=ispup;
            return _fi.SaveFolder(newForder);
        }
    }
}