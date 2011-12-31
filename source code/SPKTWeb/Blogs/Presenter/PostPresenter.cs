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

        public void Init(IPost View,bool isPostBack)
        {
            _view = View;
            if (_userSession.LoggedIn)
            {
                if (_webContext.BlogID > 0)
                {
                    if (!isPostBack)
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
                if (blog.BlogID > 0)
                {
                    Blog orginBlog = _blogRepository.GetBlogByBlogID(blog.BlogID);
                    orginBlog.Title = blog.Title;
                    orginBlog.Subject = blog.Subject;
                    orginBlog.PageName = blog.PageName;
                    orginBlog.IsPublished = blog.IsPublished;
                    orginBlog.Post = blog.Post;
                    _blogRepository.SaveBlog(orginBlog);
                    _alertService.AddUpdatedBlogPostAlert(blog);
                    _redirector.GoToViewBlogPost(orginBlog.BlogID);
                }
                else
                {
                    long id =_blogRepository.SaveBlog(blog);
                    _alertService.AddNewBlogPostAlert(blog);
                    _redirector.GoToViewBlogPost(id);
                }                
                
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