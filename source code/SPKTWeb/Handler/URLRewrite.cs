using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Domain;
using SPKTCore.Core;
using SPKTCore.Core.Impl;

namespace SPKTWeb.Handler
{
    public class URLRewrite:IHttpModule
    {
        IAccountRepository _accountRepository;
        IRedirector _redirector;
        public void Dispose()
        {            
        }

        public void Init(HttpApplication context)
        {
            context.PostResolveRequestCache += new EventHandler(Application_PostResolveRequestCache);
            _accountRepository = new AccountRepository();
            
        }

        void Application_PostResolveRequestCache(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpResponse Response = context.Response;
            HttpRequest Request = context.Request;
            String Username = Request.Path.Replace("/", "");
            //
            Account account = _accountRepository.GetAccountByUsername(Username);
            if (account != null)
            {
                _redirector = new Redirector();
                _redirector.Redirect("~/Profiles/UserProfile2.aspx?AccountID=" + account.AccountID.ToString());
            }
            



        }
    }
}