using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core;
using SPKTCore.Core.Impl;

namespace SPKTWeb.Comments.UserControl
{
    public partial class CommentFriend : System.Web.UI.UserControl
    {
        ICommentRepository _commentRepository;
        IAccountRepository _accountRepository;
        IWebContext _webContext;
        IUserSession _userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            _accountRepository = new AccountRepository();
            _commentRepository = new CommentRepository();
            _webContext = new WebContext();
            _userSession = new UserSession();
            
        }

        protected void lbt_UserName_Click(object sender, EventArgs e)
        {

        }
    }
}