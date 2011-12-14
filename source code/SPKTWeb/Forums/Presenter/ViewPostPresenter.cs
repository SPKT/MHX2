using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTWeb.Forums.Interface;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Impl;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;

namespace SPKTWeb.Forums.Presenter
{
    public class ViewPostPresenter
    {
        private IViewPost _view;
        private IWebContext _webContext;
        private IBoardPostRepository _postRepository;
        public ViewPostPresenter()
        {
            _webContext = new WebContext();
            _postRepository =new BoardPostRepository();
        }

        public void Init(IViewPost View)
        {
            _view = View;
            LoadData();
        }

        private void LoadData()
        {
            _view.LoadData(_postRepository.GetPostByID(_webContext.PostID), _postRepository.GetPostsByThreadID(_webContext.PostID));
        }
    }
}