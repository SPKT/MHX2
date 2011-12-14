using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Impl;
using SPKTCore.Core.DataAccess.Impl;
using SPKTWeb.Forums.Interface;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;

namespace SPKTWeb.Forums.Presenter
{
    public class ViewForumPresenter
    {
        private IBoardPostRepository _postRepository;
        private IViewForum _view;
        private IWebContext _webContext;
        public ViewForumPresenter()
        {
            _postRepository = new BoardPostRepository();
            _webContext = new WebContext();
        }

        public void Init(IViewForum view)
        {
            _view = view;
            LoadThreads();
        }

        private void LoadThreads()
        {
            _view.LoadDisplay(_postRepository.GetThreadsByForumID(_webContext.ForumID), _webContext.CategoryPageName, _webContext.ForumPageName, _webContext.ForumID);
        }
    }
}