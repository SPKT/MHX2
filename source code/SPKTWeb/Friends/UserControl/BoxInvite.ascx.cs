using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Domain;
using SPKTWeb.Friends.Interface;
using SPKTWeb.Friends.Presenter;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Impl;
namespace SPKTWeb.Friends
{
    public partial class BoxInvite : System.Web.UI.UserControl,IBoxFriend
    {
        BoxFriendPresenter _boxfriend;
        protected void Page_Load(object sender, EventArgs e)
        {
            _boxfriend = new BoxFriendPresenter();
            _boxfriend.Init(this);
        }
        protected void repInFriends_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                BoxFriend pdBoxFriend = e.Item.FindControl("pdBoxFriend") as BoxFriend;
                pdBoxFriend.load_InvtFriend(((Account)e.Item.DataItem));
            }
        }

        public void load_InvtFriend(List<Account> invite)
        {
            repInFriends.DataSource =invite;
            repInFriends.DataBind();
        }
        public bool ShowPanel
        {
            set { ; }
           
        }
      
    }
}