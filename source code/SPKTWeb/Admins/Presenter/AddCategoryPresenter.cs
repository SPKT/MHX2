using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core;
using SPKTCore.Core.Impl;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Admins.Presenter
{
    public class AddCategoryPresenter
    {
        IBoardService _categoryService;
        BoardCategory boardCategory;
        public AddCategoryPresenter()
        {            
            _categoryService = new BoardService();
            boardCategory = new BoardCategory();
        }
        public void AddBoardPresenter(string name, string subject, string pageName, int sortOrder)
        {
            boardCategory.Name = name;
            boardCategory.Subject = subject;
            boardCategory.PageName = pageName;
            boardCategory.SortOrder = sortOrder;
            _categoryService.SaveNewBoard(boardCategory);
        }
    }
}