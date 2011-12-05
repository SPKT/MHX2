using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.Impl
{
    public class BoardService : IBoardService
    {
        private IBoardCategoryRepository _categoryRepository;
        private IBoardForumRepository _forumRepository;

        public BoardService()
        {
            _categoryRepository = new BoardCategoryRepository();
            _forumRepository = new BoardForumRepository();
        }

        public List<BoardCategory> GetCategoriesWithForums()
        {
            List<BoardCategory> categories = _categoryRepository.GetAllCategories();
            List<BoardForum> forums = _forumRepository.GetAllForums();
            for (int i = 0; i < categories.Count(); i++)
            {
                categories[i].Forums = forums.Where(f => f.CategoryID == categories[i].CategoryID).ToList();
            }
            return categories;
        }
    }
}
