using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess.Impl
{
    public class ContentFilterRepository : IContentFilterRepository
    {
        private Connection _conn;
        public ContentFilterRepository()
        {
            _conn = new Connection();
        }

        public List<ContentFilter> GetContentFilters()
        {
            List<ContentFilter> filters = new List<ContentFilter>();
            using (SPKTDataContext dc = _conn.GetContext())
            {
                filters = dc.ContentFilters.ToList();
            }
            return filters;
        }
    }
}
