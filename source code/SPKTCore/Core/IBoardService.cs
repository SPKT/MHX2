using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core
{
    public interface IBoardService
    {
        List<BoardCategory> GetCategoriesWithForums();
        void SaveNewBoard(BoardCategory category);
        void SaveNewForum(BoardForum forum);
        List<BoardCategory> GetAllCategory();
    }
}
