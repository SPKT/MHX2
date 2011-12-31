using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Impl;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Domain;
using SPKTCore.Core;
using SPKTWeb.Photo.Interface;
using SPKTWeb.Photo.Presenter;

namespace SPKTWeb.Photo.UserControl
{
    public partial class FileListItemAlbum : System.Web.UI.UserControl,IFileAlbumList
    {
    
        FileAlbumList _present;
        protected void Page_Load(object sender, EventArgs e)
        {
            _present = new FileAlbumList();
            _present.Init(this);
        }
        protected void repFiles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                FileItem pdFileDisplay = e.Item.FindControl("file1") as FileItem;
                pdFileDisplay.LoadDisplay(((File)e.Item.DataItem));
            }
        }
        public void LoadFile(List<File> files)
        {
            repFiles.DataSource =files;
            repFiles.DataBind();
        }
    }
}