using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;
namespace SPKTCore.Core.DataAccess.Impl
{
    public class MessageFolderRepository : IMessageFolderRepository
    {
        private Connection conn;
        public MessageFolderRepository()
        {
            conn = new Connection();
        }

        public MessageFolder GetMessageFolderByID(Int32 MessageFolderID)
        {
            MessageFolder result = null;

            using (SPKTDataContext dc = conn.GetContext())
            {
                result = dc.MessageFolders.Where(mf => mf.MessageFolderID == MessageFolderID).FirstOrDefault();
            }

            return result;
        }

        public List<MessageFolder> GetMessageFoldersByAccountID(Int32 AccountID)
        {
            List<MessageFolder> result = new List<MessageFolder>();
            using (SPKTDataContext dc = conn.GetContext())
            {
                IEnumerable<MessageFolder> systemFolders = dc.MessageFolders.Where(mf => mf.IsSystem == true);
                IEnumerable<MessageFolder> userFolders = dc.MessageFolders.Where(mf => mf.AccountID == AccountID);
                result = systemFolders.Union(userFolders).ToList();
            }
            return result;
        }

        public void SaveMessageFolder(MessageFolder messageFolder)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                if (messageFolder.MessageFolderID > 0)
                {
                    dc.MessageFolders.Attach(messageFolder, true);
                }
                else
                {
                    dc.MessageFolders.InsertOnSubmit(messageFolder);
                }
                dc.SubmitChanges();
            }
        }

        public void DeleteMessageFolder(MessageFolder messageFolder)
        {
            using (SPKTDataContext dc = conn.GetContext())
            {
                dc.MessageFolders.DeleteOnSubmit(messageFolder);
                dc.SubmitChanges();
            }
        }
    }
}
