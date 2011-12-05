using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core;
using SPKTCore.Core.Impl;
using SPKTCore.Core.DataAccess.Impl;
using SPKTWeb.Messages.Interface;
using SPKTWeb.Messages.Presenter;
using System.Drawing;
namespace SPKTWeb.Messages.UserControl
{
    public partial class MessageNew : System.Web.UI.UserControl,INewMessage,ILoadMessage
    {
        IWebContext _webContext;
        IUserSession _userSession;
        IMessageRepository _messageResponstory;
        IMessageService _messageService;
        NewMessage _new;
        string sto = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            _webContext = new WebContext();
            _userSession = new UserSession();
            _messageResponstory = new MessageRepository();
            _messageService = new MessageService();
            _new = new NewMessage();
            _new.Init(this);
        }
        public void LoadReply(MessageWithRecipient message)
        {
            tb_Subject.Text = "RE: " + message.Message.Subject;
            tb_To.Text = message.Sender.UserName;
            tb_Box.Text = "<BR><BR><HR>Sent On: " + message.Message.CreateDate.ToString() + "<BR>Subject: " + message.Message.Subject + "<BR>Message: " + message.Message.Body;
        }
        public void LoadTo(string Username)
        {
            tb_To.Text = Username;
        }
       
        protected void bt_Send_Click(object sender, EventArgs e)
        {
            if (tb_To.Text == null)
            {
                tb_To.BackColor = Color.Crimson;
            }
            string[] to = tb_To.Text.Split(new char[] { ',', ';' });
            _new.SendMessage(tb_Subject.Text, tb_Box.Text, to);
            lb_Ketqua.Text = "Thông điệp của bạn đã được gửi đến " + tb_To.Text;
            tb_To.Text = "";
            tb_Subject.Text = "";
            tb_Box.Text = "";
        }

        public void LoadMessages(List<MessageWithRecipient> Messages)
        {
            throw new NotImplementedException();
        }

        public void LoadUsernameFromMessage(string Email)
        {
            tb_To.Text = Email;
        }
        public string tbTO()
        {
            return sto;
        }
        public void settbTO(string tb)
        {
            tb_To.Text = tb;
        }
    }
}