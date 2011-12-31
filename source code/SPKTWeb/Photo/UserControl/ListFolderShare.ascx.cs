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
    public partial class ListFolderShare : System.Web.UI.UserControl,IFolderShare
    {
        FolderShare _present;
        protected void Page_Load(object sender, EventArgs e)
        {
            _present = new FolderShare();
            _present.Init(this);
        }
        protected void repFiles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ShareFolderItem pdFileDisplay = e.Item.FindControl("file1") as ShareFolderItem;
                pdFileDisplay.LoadDisplay(((Folder)e.Item.DataItem));
            }
        }
        public void LoadFolder(List<Folder> folder)
        {
            repFiles.DataSource = folder;
            repFiles.DataBind();
        }
        
    }
}