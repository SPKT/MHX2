using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTWeb.Accounts.Interface;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using StructureMap;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Accounts.Presenter
{
    public class RecoverPasswordPresenter
    {
        private IRecoverPassword _view;
        private IEmail _email;
        private IAccountRepository _accountRepository;

        public RecoverPasswordPresenter()
        {
           // _email = ObjectFactory.GetInstance<IEmail>();
           // _accountRepository = ObjectFactory.GetInstance<IAccountRepository>();
            _email = new SPKTCore.Core.Impl.Email();
            _accountRepository = new SPKTCore.Core.DataAccess.Impl.AccountRepository();
        }

        public void Init(IRecoverPassword View)
        {
            _view = View;
        }

        public void RecoverPassword(string Email)
        {
            SPKTCore.Core.Domain.Account account = _accountRepository.GetAccountByEmail(Email);
            
            if (account != null)
            {
                _email.SendPasswordReminderEmail(account.Email, account.Password, account.UserName);
                _view.ShowRecoverPasswordPanel(false);
                _view.ShowMessage("An email was sent to your account!");
            }
            else
            {
                _view.ShowRecoverPasswordPanel(true);
                _view.ShowMessage("We couldn't find the account you requested.");
            }

        }
    }
}