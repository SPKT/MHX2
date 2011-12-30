using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Blogs.Interface
{
    public interface IMyBlogs
    {
        void LoadBlogs(List<Blog> Blogs);
    }
}