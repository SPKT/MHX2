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
            
            _boardService = new BoardService();
            _forumRepository =new BoardForumRepository();
            _categoryRepository = new BoardCategoryRepository();
            _redirector = new Redirector();
            _webContext = new WebContext();
        }

        public void Init(IForum View)
        {
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