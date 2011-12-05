using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Forums.Interface
{
    public interface IForum
    {
        void LoadCategories(List<BoardCategory> Categories);
    }
}