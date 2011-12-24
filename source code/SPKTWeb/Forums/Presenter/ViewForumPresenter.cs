using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Impl;
using SPKTCore.Core.DataAccess.Impl;
using SPKTWeb.Forums.Interface;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Forums.Presenter
{
    public class ViewForumPresenter
    {
        private IBoardPostRepository _postRepository;
        private IBoardForumRepository _forumRepository;
        private IViewForum _view;
        private IWebContext _webContext;
        public ViewForumPresenter()
        {
            _postRepository = new BoardPostRepository();
            _webContext = new WebContext();
            _forumRepository = new BoardForumRepository();
        }

        public void Init(IViewForum view)
        {
            _view = view;
            LoadThreads();
        }

        private void LoadThreads()
        {
            BoardForum forum = _forumRepository.GetForumByID(_webContext.ForumID);

            _view.LoadDisplay(_postRepository.GetThreadsByForumID(_webContext.ForumID),forum);
        }
    }
}