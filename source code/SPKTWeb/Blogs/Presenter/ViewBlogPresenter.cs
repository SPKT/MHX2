using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTWeb.Blogs.Interface;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Blogs.Presenter
{
    public class ViewBlogPresenter
    {
        private IViewBlog _view;
        private IBlogRepository _blogRepository;
        public ViewBlogPresenter()
        {
            _blogRepository = ObjectFactory.GetInstance<IBlogRepository>();
        }

        public void Init(IViewBlog View)
        {
            _view = View;
            _view.LoadBlogs(_blogRepository.GetLatestBlogs());
        }
    }
}