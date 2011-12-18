using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Impl;
using SPKTCore.Core.Domain;
using SPKTWeb.Messages.Interface;
using SPKTWeb.Messages.Presenter;

namespace SPKTWeb.Messages.UserControl
{
    public partial class LoadInbox : System.Web.UI.UserControl,ILoadMessage
    {
        LoadMessagePresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new LoadMessagePresenter();
            _presenter.Init(this,IsPostBack);
        }
        public void LoadMessages(List<MessageWithRecipient> Messages)
        {
            if (!IsPostBack)
            {
                repMessages.DataSource = Messages;
                repMessages.DataBind();
            }
           
        }
        protected void repMessages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                MessageBrief pdMessageDisplay = e.Item.FindControl("MessageBrief1") as MessageBrief;
                pdMessageDisplay.loadMessage(((MessageWithRecipient)e.Item.DataItem));
            }
        }
        public void LoadUsernameFromMessage(string Email)
        {
            throw new NotImplementedException();
        }
    }
}