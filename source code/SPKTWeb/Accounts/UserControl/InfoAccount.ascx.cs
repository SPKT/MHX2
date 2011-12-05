using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Domain;
using SPKTCore.Core;
using SPKTCore.Core.Impl;

namespace SPKTWeb.Accounts.UserControl
{
    public partial class InfoAccount : System.Web.UI.UserControl
    {
        IUserSession _usersession;
        protected void Page_Load(object sender, EventArgs e)
        {
            _usersession = new UserSession();
            if (_usersession != null)
            {
                lb_name_ac.Text = _usersession.CurrentUser.UserName;
                if (_usersession.CurrentProfile != null)
                {
                    lb_name.Text = _usersession.CurrentProfile.FullName;
                }
                lb_name.Text = _usersession.CurrentUser.UserName;
                lb_mail.Text = _usersession.CurrentUser.Email;
                lb_date.Text = _usersession.CurrentUser.CreateDate.ToString();
                imgAvatar.ImageUrl = "~/Image/ProfileAvatar.aspx";
            }
        }
    }
}