using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Friends.Interface
{
    public interface IProfileDisplay
    {
        void LoadDisplay(Account profile);
        //bool TestFriend(Account account);
    }
}