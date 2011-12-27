using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTWeb.Forums.Interface;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Impl;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Forums.Presenter
{
    public class ViewPostPresenter
    {
        private IViewPost _view;
        private IWebContext _webContext;
        private IBoardPostRepository _postRepository;
        private IBoardForumRepository _boardForumRepository;
        public ViewPostPresenter()
        {
            _webContext = new WebContext();
            _postRepository =new BoardPostRepository();
            _boardForumRepository = new BoardForumRepository();
        }

        public void Init(IViewPost View)
        {
            _view = View;
            LoadData();
        }

        private void LoadData()
        {
            BoardForum forum = _boardForumRepository.GetForumByID(_postRepository.GetPostByID(_webContext.PostID).ForumID);
            if(forum!=null)
                _view.LoadHeaderData(forum);
            _view.LoadData(_postRepository.GetPostByID(_webContext.PostID), _postRepository.GetPostsByThreadID(_webContext.PostID));
        }
    }
}