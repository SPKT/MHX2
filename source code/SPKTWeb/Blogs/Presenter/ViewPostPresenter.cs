using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTWeb.Blogs.Interface;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Blogs.Presenter
{
    public class ViewPostPresenter
    {
        private IViewPost _view;
        private IWebContext _webContext;
        private IBlogRepository _blogRepository;
        private IRedirector _redirector;
        private IUserSession _userSession;
        Blog blog;
        public ViewPostPresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _blogRepository = ObjectFactory.GetInstance<IBlogRepository>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
            _userSession = ObjectFactory.GetInstance<IUserSession>();
        }

        public void Init(IViewPost View)
        {
            _view = View;
            blog=_blogRepository.GetBlogByBlogID(_webContext.BlogID);
            if(blog!=null)
            {
                _view.LoadPost(blog);
                if (_userSession.LoggedIn)
                {
                    if (blog.AccountID == _userSession.CurrentUser.AccountID)
                    {
                        _view.DisplayEdit();
                    }
                }
            }
        }

        internal void GotoEditPost()
        {
            _redirector.Redirect("~/Blogs/Post.aspx?BlogID=" + _webContext.BlogID);
        }

        internal void DeletePost()
        {
            _blogRepository.DeleteBlog(blog);

        }
    }
}