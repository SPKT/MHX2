using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess.Impl;

namespace SPKTWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BoardCategory cate = new BoardCategory();
            BoardCategoryRepository re = new BoardCategoryRepository();
            cate = re.GetCategoryByCategoryID(1);
            cate.Name = "Truwowng";            
            BoardCategoryRepository re2 = new BoardCategoryRepository();
            re2.SaveCategory(cate);
        }
    }
}