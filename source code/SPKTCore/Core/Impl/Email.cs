using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using System.Net.Mail;
using System.Net;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.Impl
{
    [Pluggable("Default")]
    public class Email:IEmail
    {
        const string TO_EMAIL_ADDRESS = "mxh.spkt@gmail.com";
        const string FROM_EMAIL_ADDRESS = "mxh.spkt@gmail.com";
        const string PASSWORD = "mxh012345";
        private IFriendInvitationRepository _friendInvitationRepository;
        IWebContext _webContext;
        public void Init()
        {
            _webContext = new WebContext();
        }
        public void SendEmail(string From, string Subject, string Message)
        {
            MailMessage mm = new MailMessage(From, TO_EMAIL_ADDRESS);
            mm.Subject = Subject;
            mm.Body = Message;
            Send(mm);
        }
        public void SendEmail(string To, string CC, string BCC,
                           string Subject, string Message)
        {
            MailMessage mm = new MailMessage(FROM_EMAIL_ADDRESS, To);
            mm.CC.Add(CC);
            mm.Bcc.Add(BCC);
            mm.Subject = Subject;
            mm.Body = Message;
            mm.IsBodyHtml = true;
            Send(mm);
        }
        public void SendEmailTo(string To, string Subject, string Message)
        {
            MailMessage mm = new MailMessage(FROM_EMAIL_ADDRESS, To);
            mm.Subject = Subject;
            mm.Body = Message;
            mm.IsBodyHtml = true;
            Send(mm);
        }
        public void SendEmail(string[] To, string[] CC, string[] BCC,  string Subject, string Message)
        {
            MailMessage mm = new MailMessage();
            foreach (string to in To)
            {
                mm.To.Add(to);
            }
            foreach (string cc in CC)
            {
                mm.CC.Add(cc);
            }
            foreach (string bcc in BCC)
            {
                mm.Bcc.Add(bcc);
            }
            mm.From = new MailAddress(FROM_EMAIL_ADDRESS);
            mm.Subject = Subject;
            mm.Body = Message;
            mm.IsBodyHtml = true;
            Send(mm);
        }
        public void SendIndividualEmailsPerRecipient(string[]
           To, string Subject, string Message)
        {
            foreach (string to in To)
            {
                MailMessage mm = new
                   MailMessage(FROM_EMAIL_ADDRESS, to);
                mm.Subject = Subject;
                mm.Body = Message;
                mm.IsBodyHtml = true;
                Send(mm);
            }
        }
        private void Send(MailMessage Message)
        {
            NetworkCredential m_MailAuthentication = new NetworkCredential(TO_EMAIL_ADDRESS,PASSWORD);
            string smtpClient = "smtp.gmail.com";
            int port = 587;
            SmtpClient smtp = new SmtpClient(smtpClient, port);
            smtp.EnableSsl = true;
            smtp.Credentials = m_MailAuthentication;
            try
            {
                smtp.Send(Message);
            }
            catch (Exception ex) { ex.ToString(); }
        }
        public void SendEmailAddressVerificationEmail(string Username, string To)
        {
            //TODO: Lay noi dung email tu ben ngoai (database, tham so)
            Init();
            String emailBody = "Ban da dang ky thanh cong. De hoan thanh dang ky vui long click vao link ben duoi<br>";
            String queryStringValue = Cryptography.Encrypt(Username, ParameterSetting.EmailVerificationEncryptKey);
            string link = String.Format(_webContext.RootUrl+"Accounts/"+"{0}?{1}={2}", ParameterSetting.EmailVerificationURL, ParameterSetting.UsernameToVerifyQueryStringName, queryStringValue);
            emailBody += String.Format("<br>Click here to verify: <a href='{0}'>{0}</a>", link);
            SendEmailTo(To,ParameterSetting.VerificationEmailSubject, emailBody);

        }
        public void SendFriendInvitation(string toEmail, string Username, string GUID, string Message)
        {
            Init();
            String emailBody = "Toi muon ket ban voi ban, neu ban san long hay den tham profile cua toi<br>";
            string link = String.Format(_webContext.RootUrl+"Friends/" + "{0}?{1}={2}", ParameterSetting.FriendURL, "InvitationKey", GUID);
            emailBody += String.Format("<br>Đồng ý: <a href='{0}'>{0}</a>", link);
            SendEmailTo(toEmail, Username + ParameterSetting.InvitionFriendSubject + " : ", emailBody + Message);

        }
        public string SendInvitations(Account sender, string ToEmailArray, string Message)
        {
            string resultMessage = Message;
            foreach (string s in ToEmailArray.Split(new char[] { ',', ';' }))
            {
                _friendInvitationRepository = new SPKTCore.Core.DataAccess.Impl.FriendInvitationRepository();
                FriendInvitation friendInvitation = new FriendInvitation();
                friendInvitation.AccountID = sender.AccountID;
                friendInvitation.Email = s;
                friendInvitation.GUID = Guid.NewGuid();
                friendInvitation.BecameAccoutnID = 0;
                _friendInvitationRepository.SaveFriendInvitation(friendInvitation);

                SendFriendInvitation(s, sender.UserName, friendInvitation.GUID.ToString(), Message);
                resultMessage += " - " + s + "<BR>";
            }
            return resultMessage;
        }
        //moi
        public void SendInvitations1(Account sender, string ToEmailArray,string ms)
        {
               _friendInvitationRepository = new SPKTCore.Core.DataAccess.Impl.FriendInvitationRepository();
                FriendInvitation friendInvitation = new FriendInvitation();
                friendInvitation.AccountID = sender.AccountID;
                friendInvitation.Email = ToEmailArray;
                friendInvitation.GUID = Guid.NewGuid();
                friendInvitation.BecameAccoutnID = 0;
                _friendInvitationRepository.SaveFriendInvitation(friendInvitation);
                SendFriendInvitation(ToEmailArray, sender.UserName, friendInvitation.GUID.ToString(), ms);            
        }
        public void SendMessage(string email, string username, string message)
        {

        }
        public void SendNewMessageNotification(Account sender, string ToEmail)
        {
            
                string message = sender.UserName+ " has sent you a message on " ;
                SendEmailTo(ToEmail, "Thông điệp bạn", message);
            
        }
        //
        public void Send_Invitations(Account sender,Account invite)
        {
                _friendInvitationRepository = new SPKTCore.Core.DataAccess.Impl.FriendInvitationRepository();
                FriendInvitation friendInvitation = new FriendInvitation();
                friendInvitation.AccountID = sender.AccountID;
                friendInvitation.Email = invite.Email;
                friendInvitation.GUID = Guid.NewGuid();
                friendInvitation.BecameAccoutnID = invite.AccountID;
                _friendInvitationRepository.SaveFriendInvitation(friendInvitation);
        }
        
        public void SendPasswordReminderEmail(string To, string EncryptPassword, string Username)
        {
            String Password = Cryptography.Decrypt(EncryptPassword, Username);
            String emailBody = "Mật khẩu của user "+Username+" là:"+Password+"<br>";
            SendEmailTo(To,ParameterSetting.RecoverPassword, emailBody);
        }
    }
}
