using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SPKTCore.Core.Domain;
using SPKTWeb.Friends;
using SPKTCore.Core;
using SPKTWeb.Searchs.Interface;
using SPKTWeb.Searchs.Presenter;
using SPKTCore.Core.Impl;

namespace SPKTWeb.Search
{
    public partial class Search : System.Web.UI.Page, ISearch
    {
        private IWebContext _webContext;
        private SearchPresenter _presenter;

        protected override void OnInit(EventArgs e)
        {
            //_webContext = ObjectFactory.GetInstance<IWebContext>();
            _presenter = new SearchPresenter();
            _webContext = new SPKTCore.Core.Impl.WebContext();
            _presenter.Init(this);


            if (string.IsNullOrEmpty(_webContext.SearchText))
            {
                lblSearchTerm.Text = "Please use the search box to the left!";
            }
            else
            {
                if (!IsPostBack)
                    lblSearchTerm.Text = "Bạn muốn tìm bạn :  " + _webContext.SearchText;

                if (_webContext.SearchText.Length > 3)
                {
                    _presenter.PerformSearch(_webContext.SearchText);
                }
                else
                    lblSearchTerm.Text += " <BR><BR> Your chuoi tim kiem phai lon hon 3 ky tu!";
            }
        }

        public void LoadAccounts(List<Account> Accounts)
        {
            repAccounts.DataSource = Accounts;
            repAccounts.DataBind();
        }
       
        protected void repAccounts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                FriendProfile pd = e.Item.FindControl("pdProfileDisplay") as FriendProfile;
                pd.LoadDisplay((Account)e.Item.DataItem);
                if (_webContext.CurrentUser == null)
                    pd.ShowFriendRequestButton = false;
            }
        }
    }
}