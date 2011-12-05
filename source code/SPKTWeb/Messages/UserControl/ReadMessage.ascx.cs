using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Domain;
using SPKTCore.Core;
using SPKTCore.Core.Impl;
using SPKTWeb.Messages.Interface;
using SPKTWeb.Messages.Presenter;

namespace SPKTWeb.Messages.UserControl
{
    public partial class ReadMessage : System.Web.UI.UserControl,IReadMessage
    {
        IMessageService _messageService;
        //IWebContext _webContext;
        ReadMessagePresenter _view;
        //MessageWithRecipient mss;
        protected void Page_Load(object sender, EventArgs e)
        {
            _messageService = new MessageService();
            _view = new ReadMessagePresenter();
            _view.Init(this);
        }
        public void LoadMessage(MessageWithRecipient msg)
        {
            lb_Noidung.Text = msg.Message.Body;
            lb_Thoigian.Text = msg.Message.CreateDate.ToString();
            lbt_Nguoigui.Text = msg.Message.SendByAccountID.ToString();
        }
        protected void lbt_Traloi_Click(object sender, EventArgs e)
        {

        }
    }
}