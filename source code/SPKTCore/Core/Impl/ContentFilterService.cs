using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Domain;
using System.Web;

namespace SPKTCore.Core.Impl
{
    public class ContentFilterService : IContentFilterService
    {

        public ContentFilterService()
        {

        }

        public static string Filter(string StringToFilter)
        {
            IContentFilterRepository _contentFilterRepository =new ContentFilterRepository();
            List<ContentFilter> _contentFilters = _contentFilterRepository.GetContentFilters();

            StringBuilder sb = new StringBuilder(StringToFilter);

            //encode the final output for further security
            sb = new StringBuilder(HttpUtility.HtmlEncode(sb.ToString()));

            //replace all the dirty words and forbidden tags
            foreach (ContentFilter cf in _contentFilters)
            {
                sb.Replace(cf.StringToFilter, cf.ReplaceWith);
            }

            return sb.ToString();
        }
    }
}
