using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface IBoardCategoryRepository
    {
        BoardCategory GetCategoryByCategoryID(Int32 CategoryID);
        List<BoardCategory> GetAllCategories();
        Int32 SaveCategory(BoardCategory category);
        void DeleteCategory(BoardCategory category);
        BoardCategory GetCategoryByPageName(string PageName);
    }
}
