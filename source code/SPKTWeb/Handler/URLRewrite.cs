using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Domain;
using SPKTCore.Core;
using SPKTCore.Core.Impl;

namespace SPKTWeb.Handler
{
    public class URLRewrite : IHttpModule
    {
        IAccountRepository _accountRepository;
        IRedirector _redirector;
        private IBlogRepository _blogRepository;
        private IBoardCategoryRepository _categoryRepository;
        private IBoardForumRepository _forumRepository;
        private IBoardPostRepository _postRepository;
        private IWebContext _webContext;
        private IGroupRepository _groupRepository;
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.PostResolveRequestCache += new EventHandler(Application_PostResolveRequestCache);
            _accountRepository = new AccountRepository();
            _blogRepository = new BlogRepository();
            _categoryRepository = new BoardCategoryRepository();
            _forumRepository = new BoardForumRepository();
            _postRepository = new BoardPostRepository();
            _webContext = new WebContext();
            _groupRepository = new GroupRepository();
            _redirector = new Redirector();   

        }

        void Application_PostResolveRequestCache(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            string[] extensionsToExclude = { ".axd", ".jpg", ".gif", ".png", ".xml", ".config", ".css", ".js", ".htm", ".html" };
            foreach (string s in extensionsToExclude)
            {
                if (application.Request.PhysicalPath.ToLower().Contains(s))
                    return;
            }

            if (!System.IO.File.Exists(application.Request.PhysicalPath))
            {
                String executionPath = application.Request.CurrentExecutionFilePath.ToLower().Trim('/', ' ');
                string[] arr = executionPath.Split('/');
                switch (arr[0])
                {
                    case "blogs":
                        XuLyBlogs(context, arr);
                        break;
                    case "groups":
                        XuLyGroup(context, arr);
                        break;
                    case "mygroups":
                        XuLyMyGroups(context, arr);
                        break;
                    case "forums":
                        XuLyForums(context, arr);
                        break;
                    default:
                        HttpResponse Response = context.Response;
                        HttpRequest Request = context.Request;
                        String Username = Request.Path.Replace("/", "");
                        //
                        Account account = _accountRepository.GetAccountByUsername(Username);
                        _redirector = new Redirector();
                        if (account != null)
                            _redirector.Redirect("~/Profiles/UserProfile2.aspx?AccountID=" + account.AccountID.ToString());
                        else
                            return;
                        break;
                }
            }

        }

        private void XuLyBlogs(HttpContext context, string[] arr)
        {
            string blogPageName = arr[arr.Length - 1];
            string blogUserName = arr[arr.Length - 2];
            blogPageName = blogPageName.Replace(".aspx", "");
            if (blogPageName.ToLower() != "profileimage" && blogUserName.ToLower() != "profileavatar")
            {
                if (blogPageName == "default")
                    return;
                Account accountBlog = _accountRepository.GetAccountByUsername(blogUserName);
                if (accountBlog == null)
                    return;
                Blog blog = _blogRepository.GetBlogByPageName(blogPageName, accountBlog.AccountID);
                context.RewritePath("~/blogs/ViewPost.aspx?BlogID=" + blog.BlogID.ToString());
            }
        }

        private void XuLyForums(HttpContext context, string[] arr)
        {
            int forumsPosition = 0;
            int itemsAfterForumCount = 0;
            string categoryPageName = "";
            string forumPageName = "";
            string postPageName = "";

            itemsAfterForumCount = (arr.Length - 1) - forumsPosition;
            switch (itemsAfterForumCount)
            {
                case 0:
                    context.RewritePath(_redirector.PathViewAllForums);
                    break;
                case 1:
                    categoryPageName = arr[1];                    
                    BoardCategory cat = _categoryRepository.GetCategoryByPageName(categoryPageName);
                    if (cat != null)
                        context.RewritePath(_redirector.PathViewForumCategory + "?CatID=" + cat.CategoryID);
                    break;
                case 2:
                    categoryPageName = arr[1];
                    forumPageName = arr[2];
                    forumPageName = forumPageName.Replace(".aspx", "");
                    BoardForum forum = _forumRepository.GetForumByPageName(forumPageName);
                    if (forum != null)
                        context.RewritePath(_redirector.PathViewForum + "?ForumID=" + forum.ForumID.ToString(), true);
                    break;
                case 3:
                    categoryPageName = arr[1];
                    forumPageName = arr[2];
                    postPageName = arr[3];
                    postPageName = postPageName.Replace(".aspx", "");
                    BoardPost post = _postRepository.GetPostByPageName(postPageName);
                    if (post != null)
                        context.RewritePath(_redirector.PathViewForumPost+"?PostID=" + post.PostID.ToString(), true);
                    break;
            }            
        }
        private static void XuLyMyGroups(HttpContext context, string[] arr)
        {
            context.RewritePath("/groups/mygroups.aspx");
        }

        private void XuLyGroup(HttpContext context, string[] arr)
        {
            string groupPageName = arr[arr.Length - 1];
            groupPageName = groupPageName.Replace(".aspx", "");
            Group group = _groupRepository.GetGroupByPageName(groupPageName);
            context.RewritePath("/groups/viewgroup.aspx?GroupID=" + group.GroupID.ToString());
        }
    }
}


