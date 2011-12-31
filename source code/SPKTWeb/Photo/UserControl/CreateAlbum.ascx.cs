using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Domain;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Impl;
using SPKTCore.Core.DataAccess.Impl;
using SPKTWeb.Photo.Interface;
using SPKTWeb.Photo.Presenter;

namespace SPKTWeb.Photo.UserControl
{
    public partial class CreateAlbum : System.Web.UI.UserControl
    {
        IUserSession _usersession;
        FolderRepository _for;
        IRedirector _redirect;
        UploadAvatarPresenter up;
        protected void Page_Load(object sender, EventArgs e)
        {
            _usersession = new UserSession();
            _for = new FolderRepository();
            _redirect = new Redirector();
            up = new UploadAvatarPresenter();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Folder folder = new Folder();
            folder.AccountID = _usersession.CurrentUser.AccountID;
            folder.CreateDate = DateTime.Now;
            folder.Description = TextBox2.Text;
            folder.Name = TextBox1.Text;
            folder.IsPublicResource = Ispublic.Checked;
            folder.Location = "location";
            long id=_for.SaveFolder(folder);
            _redirect.Redirect("~/Photo/CreateAlbum.aspx?FolderID=" + id);
            StatusUpdate st = new StatusUpdate();
            StatusUpdateRepository s = new StatusUpdateRepository();
            st.AccountID = _usersession.CurrentUser.AccountID;
            st.VisibilityLevelID = 1;
            st.Status = "Tạo Album mới" + TextBox1.Text;
            st.SenderID = _usersession.CurrentUser.AccountID;
            st.FileID = folder.FileDescID;
            s.SaveStatusUpdate(st);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            up.UploadFile(FileUpload1.PostedFile, "",Ispublic.Checked);

        }
    }
}