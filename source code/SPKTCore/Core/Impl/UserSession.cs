using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.Impl
{
    [Pluggable("Default")]
    public class UserSession : IUserSession
    {
        private IWebContext _webContext;

        public UserSession()
        {
            //TODO: StructrureMap
           // _webContext = ObjectFactory.GetInstance<IWebContext>();
            _webContext = new WebContext();
        }

        public bool LoggedIn
        {
            get
            {
                return _webContext.LoggedIn;
            }
            set
            {
                _webContext.LoggedIn = value;
            }
        }

        public Account CurrentUser
        {
            get
            {
                return _webContext.CurrentUser;
            }
            set
            {
                _webContext.CurrentUser = value;
            }
        }
        public Profile CurrentProfile
        {
            get
            {
                return _webContext.CurrentProfile;
            }
            set
            {
                _webContext.CurrentProfile = value;
            }
        }
        public string Username
        {
            get
            {
                return _webContext.Username;
            }

            set
            {
                _webContext.Username = value;
            }
        }
    }
}
