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
        private IAlertService _alertService;
        public PostPresenter()
        {
            _blogRepository = ObjectFactory.GetInstance<IBlogRepository>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
            _alertService = ObjectFactory.GetInstance<IAlertService>();
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
                if (_webContext.BlogID <= 0)
                    _alertService.AddNewBlogPostAlert(blog);
                else
                    _alertService.AddUpdatedBlogPostAlert(blog);
                _redirector.Redirect("~/Blogs/ViewPost.aspx?BlogID=" + blog.BlogID);
            }
            else
            {
                _view.ShowError("Tên bài viết đã tồn tại!");
            }
        }

        internal void Delete(Blog blog)
        {
            _blogRepository.DeleteBlog(blog);
        }
    }
}