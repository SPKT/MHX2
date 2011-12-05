using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess.Impl
{
    public class MessageRecipientRepository : IMessageRecipientRepository
    {
        private Connection conn;
        public MessageRecipientRepository()
        {
            conn = new Connection();
        }

        public List<MessageRecipient> GetMessageRecipientsByMessageID(Int32 MessageID)
        {
            List<MessageRecipient> result = new List<MessageRecipient>();
            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<MessageRecipient> recipients = dc.MessageRecipients.Where(mr => mr.MessageID == MessageID);
                result = recipients.ToList();
            }
            return result;
        }

        public MessageRecipient GetMessageRecipientByID(Int32 MessageRecipientID)
        {
            MessageRecipient result = null;
            using (SPKTDataContext dc = conn.GetContext())
            {
                result = dc.MessageRecipients.Where(mr => mr.MessageRecipientID == MessageRecipientID).FirstOrDefault();
            }
            return result;
        }

        public void SaveMessageRecipient(MessageRecipient messageRecipient)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                if (messageRecipient.MessageRecipientID > 0)
                {
                    dc.MessageRecipients.Attach(messageRecipient, true);
                }
                else
                {
                    dc.MessageRecipients.InsertOnSubmit(messageRecipient);
                }
                dc.SubmitChanges();
            }
        }

        public void DeleteMessageRecipient(MessageRecipient messageRecipient)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                dc.MessageRecipients.Attach(messageRecipient, true);
                dc.MessageRecipients.DeleteOnSubmit(messageRecipient);
                dc.SubmitChanges();

                int RemainingRecipientCount =
                    dc.MessageRecipients.Where(mr => mr.MessageID == messageRecipient.MessageID).Count();
                if (RemainingRecipientCount == 0)
                {
                    dc.Messages.DeleteOnSubmit(
                        dc.Messages.Where(m => m.MessageID == messageRecipient.MessageID).FirstOrDefault());
                    dc.SubmitChanges();
                }
            }
        }
    }
}
