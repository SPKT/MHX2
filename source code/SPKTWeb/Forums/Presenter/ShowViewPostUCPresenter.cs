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
        IBoardCategoryRepository _categoryRepository;
        IBoardForumRepository _forumRepository;
        IBoardPostRepository _postRepository;
        IWebContext _webContext;
        IShowViewPostUC _view;
        BoardForum forum;
        List<BoardPost> Posts;
        public ShowViewPostUCPresenter()
        {
            _categoryRepository = new BoardCategoryRepository();
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

        internal List<BoardPost> LoadPostsInCate()
        {
            List<BoardPost> posts = new List<BoardPost>();
            List<BoardForum> forums = new List<BoardForum>();
            if (_webContext.ForumID > 0)
                forum = _forumRepository.GetForumByID(_webContext.ForumID);
            BoardCategory category = _categoryRepository.GetCategoryByCategoryID(forum.CategoryID);
            forums = _forumRepository.GetForumsByCategoryID(category.CategoryID);
            foreach (BoardForum bforum in forums)
            {
                List<BoardPost> list = _postRepository.GetThreadsByForumID(bforum.ForumID);
                posts.AddRange(list);
            }
            posts.Sort(new Comparison<BoardPost>((st1, st2) => st2.ViewCount.CompareTo(st1.ViewCount)));
            return posts.GetRange(0, 6);
        }
    }
}