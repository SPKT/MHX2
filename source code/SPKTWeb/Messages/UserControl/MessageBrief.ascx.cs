using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess;
using SPKTWeb.Messages.Interface;
using SPKTWeb.Messages.Presenter;

namespace SPKTWeb.Messages.UserControl
{
    public partial class MessageBrief : System.Web.UI.UserControl
    {
        IMessageService _messageService;
        IWebContext _webContext;
        MessageWithRecipient s;
        IAccountRepository _ac;
        IMessageRecipientRepository _ms;
        BriefMessage _bi;
        IMessageRepository _mi;
        protected void Page_Load(object sender, EventArgs e)
        {
            _messageService = new SPKTCore.Core.Impl.MessageService();
            _webContext = new SPKTCore.Core.Impl.WebContext();
            _ac = new SPKTCore.Core.DataAccess.Impl.AccountRepository();
            _ms = new SPKTCore.Core.DataAccess.Impl.MessageRecipientRepository();
            _bi = new BriefMessage();
            _mi = new SPKTCore.Core.DataAccess.Impl.MessageRepository();
            Image1.Enabled = false;
            //ImageButton1.Enabled = false;
            pn3.Visible = false;
        }
        public void loadMessage(MessageWithRecipient msg)
        {
            s = msg;
            if (msg.MessageRecipient.MessageStatusTypeID == (int)MessageStatusType.MessageStatusTypes.Unread)
            {
                statusMessage();
            }
            lb_To.Text = msg.Sender.UserName;
            lb_Subject.Text = msg.Message.Subject;
            lb_MessageID.Text = msg.MessageRecipient.MessageRecipientID.ToString();
            lb_Thoigian0.Text = msg.Message.CreateDate.ToString();
            lb_Thoigian1.Text = msg.Message.MessageID.ToString();
            if (msg.Message.Body.Length > 60)
            {
                string ss = msg.Message.Body.Substring(0, 60);
                lb_Content.Text = " --- " + ss + " ... ";
            }
            else
                lb_Content.Text = msg.Message.Body + " ... ";

            
            lb_Noidung.Text = msg.Message.Body;

        }
        public void statusMessage()
        {
            lb_To.Font.Bold = true;
            lb_Subject.Font.Bold = true;
            lb_Content.Font.Bold = true;
        }

        protected void lb_Content_Click(object sender, EventArgs e)
        {
            lb_subject_1.Text = lb_Subject.Text.ToUpper();
            lbTo_1.Text = lb_To.Text;
            lb_Thoigian.Text = "Thời gian gửi: " + lb_Thoigian0.Text;
           // MessageRecipient m = _ms.GetMessageRecipientsByMessageID(Int32.Parse(lb_MessageID.Text))[1];
            lb_Noidung.Text = lb_Noidung.Text;
            _messageService.saveMessageRecipient(Int32.Parse(lb_MessageID.Text));
            
            panel2.Visible = true;
            panel1.Visible = false;            
        }

        protected void lbt_Traloi_Click(object sender, EventArgs e)
        {
            pn3.Visible = true;
            new_ms.LoadTo(lb_To.Text);
            new_ms.LoadSubject("Trả lời [ "+lb_Subject.Text+" ] --- ");
            string sa = "======";
            new_ms.LoadContent(lb_Noidung.Text + sa);
        }

        protected void lbt_Xoa_Click(object sender, EventArgs e)
        {

        }

        protected void bt_Send_Click(object sender, EventArgs e)
        {

        }

        protected void Image1_Click(object sender, ImageClickEventArgs e)
        {
            lb_subject_1.Text = s.Message.Subject.ToUpper();
            lbTo_1.Text = s.Sender.UserName;
            lb_Thoigian.Text = "Thời gian gửi: " + s.Message.CreateDate.ToString();
            lb_Noidung.Text = s.Message.Body;
            MessageRecipient ms = _ms.GetMessageRecipientByID(s.MessageRecipient.MessageRecipientID);
            ms.MessageStatusTypeID = (int)MessageStatusType.MessageStatusTypes.Read;
            _ms.SaveMessageRecipient(ms);
            panel2.Visible = true;
            panel1.Visible = false;
        }

        protected void Image2_Click(object sender, ImageClickEventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
            lb_Subject.Font.Bold = false;
            lb_To.Font.Bold = false;
            lb_Noidung.Font.Bold = false;
            lb_subject_1.Font.Bold = false;
            lbTo_1.Font.Bold = false;
            lb_Content.Font.Bold = false;
        }
    }
}