using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using SPKTWeb.Accounts.Interface;
using StructureMap;
using SPKTCore.Core.Impl;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Accounts.Presenter
{
    public class VerifyEmailPresenter
    {
        private IWebContext _webContext;
        private IAccountRepository _accountRepository;
        public void Init(IVerifyEmail _view)
        {
           /* _webContext = ObjectFactory.GetInstance<IWebContext>();
            _accountRepository = ObjectFactory.GetInstance<IAccountRepository>();*/
            _webContext = new WebContext();
            _accountRepository = new SPKTCore.Core.DataAccess.Impl.AccountRepository();
            string username = Cryptography.Decrypt(_webContext.UsernameToVerify,ParameterSetting.EmailVerificationEncryptKey);

            Account account = _accountRepository.GetAccountByUsername(username);
            
            if (account != null)
            {
                account.EmailVerified = true;
                _accountRepository.SaveAccount(account);
                _view.ShowMessage("Bạn đã chứng thực Email thành công! Chào mừng bạn đến Mạng Xã Hội sinh Viên Sư Phạm Kỹ Thuật TP.HCM", true);
                
            }
            else
            {
                _view.ShowMessage("Chứng thực không đúng! Có thể có vấn đề trong đường link của bạn. Vui lòng thử lại", false);
            }
        }
    }
}