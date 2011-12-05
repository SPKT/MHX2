using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core
{
    [PluginFamily("Default")]
    public interface IEmail
    {
        void SendEmail(string From, string Subject, string Message);
        void SendEmail(string To, string CC, string BCC, string Subject, string Message);
        void SendEmail(string[] To, string[] CC, string[] BCC, string Subject, string Message);
        void SendIndividualEmailsPerRecipient(string[] To, string Subject, string Message);
        void SendEmailAddressVerificationEmail(string Username, string To);
        void SendPasswordReminderEmail(string To, string EncryptPassword, string Username);
        void SendEmailTo(string To, string Subject, string Message);
        string SendInvitations(Account sender, string ToEmailArray, string Message);
        void SendInvitations1(Account sender, string ToEmailArray, string ms);
        void SendNewMessageNotification(Account sender, string ToEmail);
    }
}
