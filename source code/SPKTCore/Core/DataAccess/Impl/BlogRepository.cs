using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess.Impl
{
    public class BlogRepository : IBlogRepository
    {
        private Connection _conn;
        public BlogRepository()
        {
            _conn = new Connection();
        }

        public List<Blog> GetBlogsForIndexing(int PageNumber)
        {
            List<Blog> results = new List<Blog>();
            using (SPKTDataContext dc = _conn.GetContext())
            {
                results = dc.Blogs.Skip(100 * (PageNumber - 1)).Take(100).ToList();
            }
            return results;
        }

        public Blog GetBlogByPageName(string PageName, Int32 AccountID)
        {
            Blog result = new Blog();

            using (SPKTDataContext dc = _conn.GetContext())
            {
                result = dc.Blogs.Where(b => b.PageName == PageName && b.AccountID == AccountID).FirstOrDefault();
            }

            return result;
        }

        public List<Blog> GetLatestBlogs()
        {
            List<Blog> result = new List<Blog>();
            using (SPKTDataContext dc = _conn.GetContext())
            {
                IEnumerable<Blog> blogs = (from b in dc.Blogs
                                           where b.IsPublished
                                           orderby b.UpdateDate descending
                                           select b).Take(30);
                IEnumerable<Account> accounts =
                    dc.Accounts.Where(a => blogs.Select(b => b.AccountID).Distinct().Contains(a.AccountID));
                foreach (Blog blog in blogs)
                {
                    blog.Account = accounts.Where(a => a.AccountID == blog.AccountID).FirstOrDefault();
                }
                result = blogs.ToList();
                result.Reverse();
            }
            return result;
        }

        public List<Blog> GetBlogsByAccountID(Int32 AccountID)
        {
            List<Blog> result = new List<Blog>();
            using (SPKTDataContext dc = _conn.GetContext())
            {
                IEnumerable<Blog> blogs = dc.Blogs.Where(b => b.AccountID == AccountID).OrderBy(b => b.CreateDate);
                Account account = dc.Accounts.Where(a => a.AccountID == AccountID).FirstOrDefault();
                foreach (Blog blog in blogs)
                {
                    blog.Account = account;
                }
                result = blogs.ToList();
                result.Reverse();
            }
            return result;
        }

        public Blog GetBlogByBlogID(Int64 BlogID)
        {
            Blog result = new Blog();
            using (SPKTDataContext dc = _conn.GetContext())
            {
                result = dc.Blogs.Where(b => b.BlogID == BlogID).FirstOrDefault();
                Account account = dc.Accounts.Where(a => a.AccountID == result.AccountID).FirstOrDefault();
                result.Account = account;
            }
            return result;
        }

        public bool CheckPageNameIsUnique(Blog blog)
        {
            blog = CleanPageName(blog);
            bool result = true;
            using (SPKTDataContext dc = _conn.GetContext())
            {
                int count = dc.Blogs.Where(b => b.PageName == blog.PageName && b.AccountID == blog.AccountID).Count();
                if (count > 0)
                    result = false;
            }
            return result;
        }

        private Blog CleanPageName(Blog blog)
        {
            blog.PageName = blog.PageName.Replace(" ", "-").Replace("!", "")
                .Replace("&", "").Replace("?", "").Replace(",", "");
            return blog;
        }

        public Int64 SaveBlog(Blog blog)
        {
            blog = CleanPageName(blog);
            string post = blog.Post.Replace("<body>", "").Replace("<br /></body>", "").Replace("<html>", "")
                .Replace("</html>", "").Replace("<head>", "").Replace("</head>", "");
            blog.Post = post;
            using (SPKTDataContext dc = _conn.GetContext())
            {
                if (blog.BlogID > 0)
                {
    
                    blog.UpdateDate = DateTime.Now;
                    dc.Blogs.Attach(blog, true);
                }
                else
                {
                    blog.CreateDate = DateTime.Now;
                    blog.UpdateDate = DateTime.Now;
                    dc.Blogs.InsertOnSubmit(blog);
                }
                dc.SubmitChanges();
            }
            return blog.BlogID;
        }

        public void DeleteBlog(Int64 BlogID)
        {
            using (SPKTDataContext dc = _conn.GetContext())
            {
                Blog blog = dc.Blogs.Where(b => b.BlogID == BlogID).FirstOrDefault();
                dc.Blogs.DeleteOnSubmit(blog);
                dc.SubmitChanges();
            }
        }

        public void DeleteBlog(Blog blog)
        {
            using (SPKTDataContext dc = _conn.GetContext())
            {
                dc.Blogs.Attach(blog, true);
                dc.Blogs.DeleteOnSubmit(blog);
                dc.SubmitChanges();
            }
        }
    }
}
