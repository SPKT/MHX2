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
        public PostPresenter()
        {
            _blogRepository = ObjectFactory.GetInstance<IBlogRepository>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        public void Init(IPost View)
        {
            _view = View;
            if(_webContext.BlogID > 0)
            {
                _view.LoadPost(_blogRepository.GetBlogByBlogID(_webContext.BlogID));
            }
        }

        public void SavePost(Blog blog)
        {
            bool result = _blogRepository.CheckPageNameIsUnique(blog);
            if (result)
            {
                blog.AccountID = _webContext.CurrentUser.AccountID;
                _blogRepository.SaveBlog(blog);
            }
            else
            {
                _view.ShowError("The page name you have chosen is in use.  Please choose a different page name!");
            }
        }
    }
}