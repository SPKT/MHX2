using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTWeb.Blogs.Interface;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Blogs.Presenter
{
    public class MyBlogsPresenter
    {

        private IMyBlogs _view;
        private IBlogRepository _blogRepository;
        private IWebContext _webContext;
        private IUserSession _userSession;
        private IRedirector _redirector;
        public MyBlogsPresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _blogRepository = ObjectFactory.GetInstance<IBlogRepository>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
            _userSession = ObjectFactory.GetInstance<IUserSession>();
        }

        public void Init(IMyBlogs View)
        {
            _view = View;
            if (_webContext.CurrentUser != null)
                _view.LoadBlogs(_blogRepository.GetBlogsByAccountID(_webContext.CurrentUser.AccountID));
            else
            {
                if (_userSession.LoggedIn)
                    _view.LoadBlogs(_blogRepository.GetBlogsByAccountID(_userSession.CurrentUser.AccountID));
                else
                    _redirector.GoToAccountLoginPage();
            }

        }

        public void EditBlog(Int64 BlogID)
        {
            _redirector.GoToBlogsPostEdit(BlogID);
        }

        public void DeletedBlog(Int64 BlogID)
        {
            _blogRepository.DeleteBlog(BlogID);
            Init(_view);
        }
    }
}