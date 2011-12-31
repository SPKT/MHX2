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
using SPKTWeb.Friends.Interface;
using SPKTWeb.Friends.Presenter;

namespace SPKTWeb.Photo.UserControl
{
    public partial class FileItem : System.Web.UI.UserControl
    {
        protected UserSession _usersession;
        IWebContext _webcontext;
        //ShowFriendPresenter _present;
        protected void Page_Load(object sender, EventArgs e)
        {
            _webcontext = new WebContext();
            
        }
        public void LoadDisplay(File file)
        {
            IWebContext _webcontext = new WebContext();
            UserSession _usersession = new UserSession();
            if (_usersession.CurrentUser!=null)
            {
                if (_webcontext.AccountID > 0 && _usersession.CurrentUser.AccountID != _webcontext.AccountID)
                {
                    if (file.IsPublicResource == true)
                    {
                        Image1.ImageUrl = "~/Photo/ProfileAvatar.aspx?FileID=" + file.FileID;
                        Name.Text = file.FileName;
                        Date.Text = file.CreateDate.ToString();
                        Desc.Text = file.Description;
                        FileID.Text = file.FileID.ToString();
                        Ispublic.Checked = true;
                        LoadFriend();
                    }
                    else div1.Visible = false;
                }
                else
                {
                    Image1.ImageUrl = "~/Photo/ProfileAvatar.aspx?FileID=" + file.FileID;
                    Name.Text = file.FileName;
                    Date.Text = file.CreateDate.ToString();
                    Desc.Text = file.Description;
                    FileID.Text = file.FileID.ToString();
                    Ispublic.Checked = file.IsPublicResource;
                    LoadFriend();
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            AccountRepository ac = new AccountRepository();
            FileRepository fr = new FileRepository();
            WebContext webcontext = new WebContext();
            UserSession usersession = new UserSession();
            _usersession = new UserSession();

            if (webcontext.AccountID > 0 && usersession.CurrentUser.AccountID != webcontext.AccountID)
            {
                Share s = new Share();
                Account a = ac.GetAccountByID(webcontext.AccountID);
                File f = fr.GetFileByID(long.Parse(FileID.Text));
                s.Shared(_usersession.CurrentUser, a, f);
                pnm.Visible = false;
            }
            else
            {
                pnm.Visible = true;
            }
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
            AccountRepository ac=new AccountRepository();
            FileRepository fr=new FileRepository();
            _usersession=new UserSession();
            Share s = new Share();
            Account a=ac.GetAccountByUsername(friend.Text);
            File f=fr.GetFileByID(long.Parse(FileID.Text));
            s.Shared(a, _usersession.CurrentUser, f);
        }
    }
}