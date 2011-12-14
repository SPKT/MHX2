using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;
using SPKTCore.Core.Impl;
using System.Diagnostics;

namespace SPKTCore.Core.DataAccess.Impl
{
    public class FolderRepository : IFolderRepository
    {
        private Connection conn;
        private ICache _cache;
        public FolderRepository()
        {
            conn = new Connection();
            _cache = new Cache();
        }

        public List<Folder> GetFoldersByAccountID(Int32 AccountID)
        {
            List<Folder> result = new List<Folder>();
            string cache_key = "GetFoldersByAccountID_" + AccountID.ToString();

            Stopwatch sw = new Stopwatch();


            if (_cache.Exists(cache_key))
            {
                sw.Reset();
                sw.Start();
                //TODO: bo tam de bien dich
               // result = XMLService.Deserialize<List<Folder>>(_cache.Get(cache_key).ToString());
                sw.Stop(); //46ms from cache
            }
            else
            {
                sw.Reset();
                sw.Start();
                using (SPKTDataContext dc = conn.GetContext())
                {
                    var account = dc.Accounts.Where(a => a.AccountID == AccountID).FirstOrDefault();

                    IEnumerable<Folder> folders = (from f in dc.Folders
                                                   where f.AccountID == AccountID
                                                   orderby f.CreateDate descending
                                                   select f);
                    foreach (Folder folder in folders)
                    {
                        var fullPath = (from f in dc.Files
                                        join ft in dc.FileTypes on f.FileTypeID equals ft.FileTypeID
                                        where f.DefaultFolderID == folder.FolderID
                                        select new
                                        {
                                            FullPathToCoverImage = f.CreateDate.Year.ToString() +
                                                                   f.CreateDate.Month.ToString() +
                                                                   "/" + f.FileSystemName + "__S." +
                                                                   ft.Name
                                        }).FirstOrDefault();
                        if (fullPath != null)
                            folder.FullPathToCoverImage = fullPath.FullPathToCoverImage;
                        else
                            folder.FullPathToCoverImage = "default.jpg";
                        if (account != null)
                            folder.Username = account.UserName;
                    }
                    result = folders.ToList();
                }
                sw.Stop(); //190ms from db
                //TODO: tam bo de compile
                //_cache.Set(cache_key, XMLService.Serialize(result));
            }
            return result;
        }

        public List<Folder> GetFriendsFolders(List<Friend> Friends)
        {
            List<Folder> result = new List<Folder>();
            foreach (Friend friend in Friends)
            {
                if (result.Count < 50)
                {
                    List<Folder> folders = GetFoldersByAccountID(friend.MyFriendAccountID);
                    IEnumerable<Folder> result2 = result.Union(folders);
                    result = result2.ToList();
                }
                else
                    break;
            }
            return result;
        }

        public Folder GetFolderByID(Int64 FolderID)
        {
            Folder folder;
            using (SPKTDataContext dc = conn.GetContext())
            {
                folder = dc.Folders.Where(f => f.FolderID == FolderID).FirstOrDefault();
            }
            return folder;
        }

        public Int64 SaveFolder(Folder folder)
        {
            Int64 result = 0;
            using (SPKTDataContext dc = conn.GetContext())
            {
                if (folder.FolderID > 0)
                    dc.Folders.Attach(folder, true);
                else
                {
                    folder.CreateDate = DateTime.Now;
                    dc.Folders.InsertOnSubmit(folder);
                }

                dc.SubmitChanges();
                result = folder.FolderID;
            }
            return result;
        }

        public void DeleteFolder(Folder folder)
        {
            string cache_key = "GetFoldersByAccountID_" + folder.AccountID;

            if (_cache.Exists(cache_key))
                _cache.Delete(cache_key);

            using (SPKTDataContext dc = conn.GetContext())
            {
                dc.Folders.Attach(folder, true);
                dc.Folders.DeleteOnSubmit(folder);
                dc.SubmitChanges();
            }
        }
    }
}
