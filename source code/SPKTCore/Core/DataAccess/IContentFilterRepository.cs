using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface IContentFilterRepository
    {
        List<ContentFilter> GetContentFilters();
    }
}
