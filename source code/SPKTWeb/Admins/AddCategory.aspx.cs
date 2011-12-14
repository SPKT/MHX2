using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Admins.Presenter;

namespace SPKTWeb.Admins
{
    public partial class AddCategory : System.Web.UI.Page
    {
        AddCategoryPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new AddCategoryPresenter();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            _presenter.AddBoardPresenter(txtName.Text, txtSubject.Text, txtPageName.Text,int.Parse(txtSortOrder.Text));
        }
    }
}