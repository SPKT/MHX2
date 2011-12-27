using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Forums.Interface;
using SPKTWeb.Forums.Presenter;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Forums.UserControl
{
    public partial class ViewTopPost : System.Web.UI.UserControl,IShowViewPostUC
    {
        ShowViewPostUCPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ShowViewPostUCPresenter();
            _presenter.Init(this);
        }

        public void LoadPost()
        {
            List<BoardPost> posts = _presenter.LoadPosts();
            repPosts.DataSource = posts;
            repPosts.DataBind();
        }
    }
}