using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core;
using SPKTCore.Core.Domain;
using SPKTCore.Core.Impl;

namespace SPKTWeb
{
    public abstract class SecurityPageBase : System.Web.UI.Page, IPermissionContent
    {
        protected IWebContext _webContext;
        protected IRedirector _redirector;
        
        public SecurityPageBase()
        {
            _redirector = new Redirector();
            _webContext = new WebContext();   
            this.Load += new EventHandler(SecurityPageBase_Load);
        }

        void SecurityPageBase_Load(object sender, EventArgs e)
        {
            _Permission = InitPermistionBeforPageLoad();
        }
        public abstract PermissionType InitPermistionBeforPageLoad();

        PermissionType _Permission;
        public SPKTCore.Core.Domain.PermissionType UserPermission
        {
            get { return _Permission; }
        }

    }
}