using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core;
using SPKTCore.Core.Domain;
using SPKTCore.Core.Impl;
using SPKTWeb.Admins.Interface;

namespace SPKTWeb.Admins.Presenter
{
    public class AddForumPresenter
    {
        IBoardService _categoryService;
        BoardForum forum;
        List<BoardCategory> boardCategorys;
        IAddForum _view;
        public AddForumPresenter()
        {            
            _categoryService = new BoardService();
            forum = new BoardForum();
        }
        public void Init(IAddForum view)
        {
            _view = view;
            boardCategorys = _categoryService.GetAllCategory();
            _view.LoadCategory(boardCategorys);
        }
        public void AddForum(string name, string subject, string pageName, int category)
        {
            forum.Name = name;
            forum.Subject = subject;
            forum.PageName = pageName;
            forum.CategoryID = category;
            _categoryService.SaveNewForum(forum);
        }
    }
}