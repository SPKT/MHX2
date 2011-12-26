using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core;
using SPKTCore.Core.Impl;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Admins
{
    public partial class Manage : System.Web.UI.Page
    {
        IWebContext _webContext;
        IUserSession _userSession;
        IRedirector _redirector;
        IPermissionRepository _permissionRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            _webContext = new WebContext();
            _userSession=new UserSession();
            if (!_userSession.LoggedIn)
            {
                _redirector.GoToAccountLoginPage();
            }
            else
            {
                _permissionRepository = new PermissionRepository();
                Account account=_userSession.CurrentUser;
                List<Permission> permissions = _permissionRepository.GetPermissionsByAccountID(account.AccountID);
                int i=0;
                foreach (Permission p in permissions)
                {
                    if (p.PermissionID != _permissionRepository.GetPermissionByName("Admin").PermissionID)
                    {
                        i++;
                    }
                }
                if (i == permissions.Count)
                {
                    linkAddcate.Visible = false;
                    linkAddForum.Visible = false;
                    lblMessage.Text = "Chỉ có Addmin mới có quyền xem trang này";
                }
            }
                
        }
    }
}