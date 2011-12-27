using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;
using SPKTWeb.Forums.UserControl;
using SPKTWeb.Forums.Interface;
using SPKTCore.Core.Domain;
using SPKTCore.Core;
using SPKTCore.Core.Impl;

namespace SPKTWeb.Forums.Presenter
{
    public class ShowViewPostUCPresenter
    {
        IBoardForumRepository _forumRepository;
        IBoardPostRepository _postRepository;
        IWebContext _webContext;
        IShowViewPostUC _view;
        BoardForum forum;
        List<BoardPost> Posts;
        public ShowViewPostUCPresenter()
        {
            _forumRepository = new BoardForumRepository();
            _postRepository = new BoardPostRepository();
            _webContext = new WebContext();
            Posts = new List<BoardPost>();
            forum = new BoardForum();
        }

        public void Init(IShowViewPostUC view)
        {
            _view = view;
            if(_webContext.ForumID>0)
                forum=_forumRepository.GetForumByID(_webContext.ForumID);
            
        }

        public List<BoardPost> LoadPosts()
        {
            return _postRepository.GetTopPost(_webContext.ForumID);
        }
    }
}