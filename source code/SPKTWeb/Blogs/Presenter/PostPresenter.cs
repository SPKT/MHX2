using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core;
using SPKTWeb.Blogs.Interface;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Blogs.Presenter
{
    public class PostPresenter
    {
        private IBlogRepository _blogRepository;
        private IWebContext _webContext;
        private IPost _view;
        private IUserSession _userSession;
        private IRedirector _redirector;
        public PostPresenter()
        {
            _blogRepository = ObjectFactory.GetInstance<IBlogRepository>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
        }

        public void Init(IPost View)
        {
            _view = View;
            if (_userSession.LoggedIn)
            {
                if (_webContext.BlogID > 0)
                {
                    _view.LoadPost(_blogRepository.GetBlogByBlogID(_webContext.BlogID));
                }
            }
            else
                _redirector.GoToAccountLoginPage();
        }

        public void SavePost(Blog blog)
        {
            bool result = _blogRepository.CheckPageNameIsUnique(blog);
            if (result)
            {
                blog.AccountID = _webContext.CurrentUser.AccountID;
                _blogRepository.SaveBlog(blog);
                _redirector.Redirect("~/Blogs/ViewPost.aspx?BlogID=" + blog.BlogID);
            }
            else
            {
                _view.ShowError("The page name you have chosen is in use.  Please choose a different page name!");
            }
        }

        internal void Delete(Blog blog)
        {
            _blogRepository.DeleteBlog(blog);
        }
    }
}