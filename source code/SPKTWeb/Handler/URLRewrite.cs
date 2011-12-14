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
                if (application.Request.PhysicalPath.ToLower().Contains("blogs"))
                {
                    string[] arr = application.Request.PhysicalPath.ToLower().Split('\\');
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
                    else
                    {
                        return;
                    }
                }
 
                else if (application.Request.PhysicalPath.ToLower().Contains("groups") && _webContext.GroupID == 0)
                {
                    string[] arr = application.Request.PhysicalPath.ToLower().Split('\\');
                    string groupPageName = arr[arr.Length - 1];
                    groupPageName = groupPageName.Replace(".aspx", "");
                    Group group = _groupRepository.GetGroupByPageName(groupPageName);
                    context.RewritePath("/groups/viewgroup.aspx?GroupID=" + group.GroupID.ToString());
                }
                else if (application.Request.PhysicalPath.ToLower().Contains("mygroups") && application.Request.PhysicalPath.ToLower().Contains("groups"))
                {

                    context.RewritePath("/groups/mygroups.aspx");
                }

                else if (application.Request.PhysicalPath.ToLower().Contains("forums"))
                {
                    string[] arr = application.Request.PhysicalPath.ToLower().Split('\\');
                    int forumsPosition = 0;
                    int itemsAfterForums = 0;
                    string categoryPageName = "";
                    string forumPageName = "";
                    string postPageName = "";

                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i].ToLower() == "forums")
                        {
                            forumsPosition = i;
                            break;
                        }
                    }

                    itemsAfterForums = (arr.Length - 1) - forumsPosition;

                    if (itemsAfterForums == 2)
                    {
                        categoryPageName = arr[arr.Length - 2];
                        forumPageName = arr[arr.Length - 1];
                        forumPageName = forumPageName.Replace(".aspx", "");
                        BoardForum forum = _forumRepository.GetForumByPageName(forumPageName);
                        context.RewritePath("/forums/ViewForum.aspx?ForumID=" + forum.ForumID.ToString() +
                                            "&CategoryPageName=" + categoryPageName + "&ForumPageName=" + forumPageName, true);
                    }
                    else if (itemsAfterForums == 3)
                    {
                        categoryPageName = arr[arr.Length - 3];
                        forumPageName = arr[arr.Length - 2];
                        postPageName = arr[arr.Length - 1];
                        postPageName = postPageName.Replace(".aspx", "");
                        BoardPost post = _postRepository.GetPostByPageName(postPageName);
                        context.RewritePath("/forums/ViewPost.aspx?PostID=" + post.PostID.ToString(), true);
                    }
                }
                else
                {
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
                }


            }

        }
    }
}

