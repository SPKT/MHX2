using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using SPKTWeb.Photo.Interface;
using SPKTWeb.Photo.Presenter;
using SPKTCore.Core.Impl;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Domain;
namespace SPKTWeb.Photo
{
    public partial class ManagePhoto : System.Web.UI.Page
    {
        FolderRepository _for;
        UserSession _usersession;
        WebContext _webcontext;
        
        UploadAvatarPresenter up;
        Redirector re;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //file1.Visible = false;
            _usersession = new UserSession();
            _webcontext = new WebContext();
            _for = new FolderRepository();
            re = new Redirector();
            if (_usersession.CurrentUser != null)
            {
               countA.Text=(_for.GetFoldersByAccountID1(_usersession.CurrentUser.AccountID)).Count.ToString();
              // pn.Height = 200 * (int.Parse(countA.Text));
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            ////abumID=addAlbum.addAlbum(_usersession.CurrentUser.AccountID, TextBox1.Text, true, TextBox2.Text, 1);
            ////file1.Visible = true;
            //Redirector re = new Redirector();
            //re.Redirect("http://localhost:24207/Samples/Advanced1?AlbumID=" + TextBox1.Text + "&Desc=" + TextBox2.Text);
            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            up = new UploadAvatarPresenter();
            up.UploadFile(FileUpload1.PostedFile, TextBox2.Text,Ispublic.Checked);
            
        }

        protected void lb_taomoi_Click(object sender, EventArgs e)
        {
           // di.Visible = false;
            //di1.Visible = true;
            re.Redirect("~/Photo/CreateAlbum.aspx");
        }
        protected void lb_taomoi1_Click(object sender, EventArgs e)
        {
            ListFolderShare1.Visible = false;
            LoadAlbum1.Visible = false;
        }
        protected void lb_album_Click(object sender, EventArgs e)
        {
            FileListItem1.Visible = false;
            ListFileShare1.Visible = false;
        }
    }
}