using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using SPKTWeb.Searchs.Interface;
using SPKTCore.Core.Impl;
using StructureMap;
namespace SPKTWeb.Searchs.Presenter
{
    public class SearchPresenter
    {
        private ISearch _view;
        private IAccountRepository _accountRepository;
        private IRedirector _redirector;
        private IProfileRepository _profileRepository;
        public void Init(ISearch view)
        {
            _view = view;
            _accountRepository = new SPKTCore.Core.DataAccess.Impl.AccountRepository();
            _profileRepository = new SPKTCore.Core.DataAccess.Impl.ProfileRepository();
            _redirector = new SPKTCore.Core.Impl.Redirector();
            
        }

        public void PerformSearch(string SearchText)
        {
            _view.LoadAccounts(_accountRepository.SearchAccounts(SearchText));
            //ss.ShowSearch(SearchText);
            //_view.LoadProfiles(ss);
        }

    }
}