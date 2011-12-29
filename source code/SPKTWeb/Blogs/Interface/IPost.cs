using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Blogs.Interface
{
    public interface IPost
    {
        void LoadPost(Blog blog);
        void ShowError(string ErrorMessage);
    }
}