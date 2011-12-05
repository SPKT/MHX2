using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess;

namespace SPKTWeb
{
    public partial class AddData : System.Web.UI.Page
    {
        IPermissionRepository _permissionRe = new PermissionRepository();
        Permission _permission = new Permission();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            _permission.Name = txtPermissionName.Text;
            _permissionRe.SavePermission(_permission);

        }
    }
}