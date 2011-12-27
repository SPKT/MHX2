using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTWeb.Forums.Interface;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Impl;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Forums.Presenter
{
    public class ForumPresenter
    {
        private IBoardService _boardService;
        private IForum _view;
        private IRedirector _redirector;
        private IBoardForumRepository _forumRepository;
        private IBoardCategoryRepository _categoryRepository;
        private IWebContext _webContext;
        public ForumPresenter()
        {

            _boardService = ObjectFactory.GetInstance<IBoardService>();
            _forumRepository =new BoardForumRepository();
            _categoryRepository = new BoardCategoryRepository();
            _redirector = new Redirector();
            _webContext = new WebContext();
        }

        public void Init(IForum View)
        {
            if (System.Web.Security.Roles.IsUserInRole("admin"))
            {
                HttpContext.Current.Response.Write("<br><b>Co quyen ADMIN</B><br>");
            }else
                HttpContext.Current.Response.Write("<br><b>Khong co quyen ADMIN</B><br>");
            _view = View;
            bool IsLogin = _webContext.LoggedIn;
            _view.LoadCategories(_boardService.GetCategoriesWithForums());
        }

        public void GoToForum(string ForumPageName)
        {
            BoardForum forum = _forumRepository.GetForumByPageName(ForumPageName);
            BoardCategory category = _categoryRepository.GetCategoryByCategoryID(forum.CategoryID);
            _redirector.GoToForumsForumView(forum.PageName,category.PageName);
        }
    }
}