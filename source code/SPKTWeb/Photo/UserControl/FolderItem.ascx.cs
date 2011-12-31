using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SPKTCore.Core.Domain;
using SPKTWeb.Photo.Interface;
using SPKTWeb.Photo.Presenter;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Impl;
using SPKTCore.Core;

namespace SPKTWeb.Photo.UserControl
{
    public partial class FolderItem : System.Web.UI.UserControl
    {
        protected UserSession _usersession;
       
        Redirector _re;
        protected void Page_Load(object sender, EventArgs e)
        {            
        }
        public void LoadDisplay(Folder fo)
        {
            IWebContext _webcontext = new WebContext();
            UserSession _usersession = new SPKTCore.Core.Impl.UserSession();
            if (_webcontext.AccountID > 0 && _usersession.CurrentUser.AccountID != _webcontext.AccountID)
            {
                if (fo.IsPublicResource == true)
                {
                    if (fo.FileDescID != null || fo.FileDescID != 0)
                    {
                        Image1.ImageUrl = "~/Photo/ProfileAvatar.aspx?FileID=" + fo.FileDescID;
                    }
                    else
                        Image1.ImageUrl = "~/Photo/ProfileAvatar.aspx?FileID=" + 60;
                    Name.Text = "Tên Album: " + fo.Name;
                    Date.Text = "Ngày tạo: " + fo.CreateDate.ToString();
                    Desc.Text = "Mô tả :" + fo.Description;
                    FolderID.Text = fo.FolderID.ToString();
                    Ispublic.Checked = true;
                }
                else div1.Visible = false;
            }
            else
            {
                if (fo.FileDescID != null || fo.FileDescID != 0)
                {
                    Image1.ImageUrl = "~/Photo/ProfileAvatar.aspx?FileID=" + fo.FileDescID;
                }
                else
                    Image1.ImageUrl = "~/Photo/ProfileAvatar.aspx?FileID=" + 60;
                Name.Text = "Tên Album: " + fo.Name;
                Date.Text = "Ngày tạo: " + fo.CreateDate.ToString();
                Desc.Text = "Mô tả :" + fo.Description;
                FolderID.Text = fo.FolderID.ToString();
                Ispublic.Checked = fo.IsPublicResource;
                LoadFriend();
            }
        }

        protected void Image1_Click(object sender, ImageClickEventArgs e)
        {
            Redirector _re = new Redirector();
            _re.Redirect("~/Photo/CreateAlbum.aspx?FolderID="+long.Parse(FolderID.Text));
        }

        protected void Name_Click(object sender, EventArgs e)
        {
            Redirector _re = new Redirector();
            _re.Redirect("~/Photo/CreateAlbum.aspx?FolderID=" + long.Parse(FolderID.Text));
        }
        public void LoadFriend()
        {
            UserSession _usersession = new UserSession();
            FriendService frs = new FriendService();
            List<Object> usename = new List<object>();
            foreach (Account a in frs.SearchFriend(_usersession.CurrentUser))
            {
                usename.Add(a.DisplayName);
            }
            friend.DataSource = usename;
            friend.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            AccountRepository ac = new AccountRepository();
            FolderRepository fr = new FolderRepository();
            WebContext webcontext = new WebContext();
            UserSession usersession = new UserSession();
            _usersession = new UserSession();
                Share s = new Share();
                Account a = ac.GetAccountByUsername(friend.Text);
                Folder f = fr.GetFolderByID(long.Parse(FolderID.Text));
                s.Shared1(a, _usersession.CurrentUser, f);
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            AccountRepository ac = new AccountRepository();
            FolderRepository fr = new FolderRepository();
            WebContext webcontext = new WebContext();
            UserSession usersession = new UserSession();
            _usersession = new UserSession();

            if (webcontext.AccountID > 0 && usersession.CurrentUser.AccountID != webcontext.AccountID)
            {
                pnm.Visible = false;
                Share s = new Share();
                Account a = ac.GetAccountByID(webcontext.AccountID);
                Folder f = fr.GetFolderByID(long.Parse(FolderID.Text));
                s.Shared1(_usersession.CurrentUser, a, f);
            }
            else
            {
                pnm.Visible = true;
            }
        }
    }
}