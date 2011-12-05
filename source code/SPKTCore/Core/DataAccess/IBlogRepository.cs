using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface IBlogRepository
    {
        List<Blog> GetBlogsByAccountID(Int32 AccountID);
        Blog GetBlogByBlogID(Int64 BlogID);
        Int64 SaveBlog(Blog blog);
        void DeleteBlog(Blog blog);
        List<Blog> GetLatestBlogs();
        Blog GetBlogByPageName(string PageName, Int32 AccountID);
        bool CheckPageNameIsUnique(Blog blog);
        void DeleteBlog(Int64 BlogID);
        List<Blog> GetBlogsForIndexing(int PageNumber);
    }
}
