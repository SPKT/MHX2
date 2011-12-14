using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Admins.Interface;
using SPKTWeb.Admins.Presenter;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Admins
{
    public partial class AddForum : System.Web.UI.Page, IAddForum
    {
        AddForumPresenter _persenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _persenter = new AddForumPresenter();
            _persenter.Init(this);
        }
        public void LoadCategory(List<BoardCategory> categorys)
        {
            ListItem item;
            foreach (BoardCategory category in categorys)
            {
                item = new ListItem(category.Name, category.CategoryID.ToString());
                ddlcategory.Items.Add(item);   
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            _persenter.AddForum(txtName.Text, txtSubject.Text, txtPageName.Text,int.Parse(ddlcategory.SelectedValue));
            txtName.Text = "";
            txtPageName.Text = "";
            txtSubject.Text = "";
        }

    }
}