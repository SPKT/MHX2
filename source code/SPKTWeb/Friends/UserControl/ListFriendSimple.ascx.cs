using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Impl;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Domain;
using SPKTCore.Core;
using SPKTWeb.Friends.Interface;
using SPKTWeb.Friends.Presenter;

namespace SPKTWeb.Friends
{
    public partial class ListFriendSimple : System.Web.UI.UserControl,IShowFriend
    {
        protected ShowFriendPresenter _showfriendpresenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _showfriendpresenter = new ShowFriendPresenter();
            _showfriendpresenter.Init(this);
        }
        protected void repFriends_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                FriendSimple pdFriendDisplay = e.Item.FindControl("pdFriendSimple") as FriendSimple;
                pdFriendDisplay.LoadDisplay(((Account)e.Item.DataItem));
            }
        }

        public void LoadFriend(List<Account> Accounts)
        {
            repFriends.DataSource = Accounts;
            repFriends.DataBind();
        }
    }
}