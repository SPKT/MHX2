using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Groups.Interface;
using SPKTWeb.UserControl;
using SPKTCore.Core.Domain;
using SPKTWeb.Groups.Presenter;
using SPKTCore.Core;
using SPKTCore.Core.Impl;

namespace SPKTWeb.Groups.UserControl
{
    public partial class ManageMember : System.Web.UI.UserControl, IMembers
    {
        private MembersPresenter _presenter;
        private IWebContext _webContext;
        protected void Page_Load(object sender, EventArgs e)
        {
            _webContext = new WebContext();
            _presenter = new MembersPresenter();
            _presenter.Init(this, IsPostBack);

            if (_webContext.PageNumber == 1 || _webContext.PageNumber == 0)
                lbPrevious.Visible = false;
            if (repMembers.Items.Count == 0)
                lbNext.Visible = false;
        }

        public void SetButtonsVisibility(bool Visible)
        {
            pnlButtons.Visible = Visible;
        }

        public void LoadData(List<Account> Members, List<Account> MembersToApprove)
        {
            repMembers.DataSource = Members;
            repMembers.DataBind();
            repMembersToApprove.DataSource = MembersToApprove;
            repMembersToApprove.DataBind();
        }

        public void lbPrevious_Click(object sender, EventArgs e)
        {
            _presenter.Previous();
        }

        public void lbNext_Click(object sender, EventArgs e)
        {
            _presenter.Next();
        }

        public void ShowMessage(string Message)
        {
            lblMessage.Text = Message;
        }

        public void repMembers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                ProfileDisplay p = e.Item.FindControl("Profile1") as ProfileDisplay;
                CheckBox chkProfile = e.Item.FindControl("chkProfile") as CheckBox;

                p.LoadDisplay(((Account)e.Item.DataItem));
                chkProfile.Attributes.Add("AccountID", ((Account)e.Item.DataItem).AccountID.ToString());
            }
        }

        public void repMembersToApprove_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                ProfileDisplay p = e.Item.FindControl("Profile1") as ProfileDisplay;
                CheckBox chkProfile = e.Item.FindControl("chkProfile") as CheckBox;

                p.LoadDisplay(((Account)e.Item.DataItem));
                chkProfile.Attributes.Add("AccountID", ((Account)e.Item.DataItem).AccountID.ToString());
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            _presenter.ApproveMembers(ExtractMembersToApproveIDs());
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> members1 = ExtractMembersToApproveIDs();
            List<int> members2 = ExtractApprovedMemberIDs();
            List<int> members3 = members1.Union(members2).ToList();
            _presenter.DeleteMembers(members3);
        }

        protected void btnPromoteToAdmin_Click(object sender, EventArgs e)
        {
            _presenter.PromoteMembers(ExtractApprovedMemberIDs());
        }

        protected void btnDemoteAdmins_Click(object sender, EventArgs e)
        {
            _presenter.DemoteMembers(ExtractApprovedMemberIDs());
        }

        private List<int> ExtractApprovedMemberIDs()
        {
            return ExtractMemberIDs(repMembers);
        }

        private List<int> ExtractMembersToApproveIDs()
        {
            return ExtractMemberIDs(repMembersToApprove);
        }

        private List<int> ExtractMemberIDs(Repeater repeater)
        {
            List<int> result = new List<int>();
            foreach (RepeaterItem item in repeater.Items)
            {
                if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
                {
                    CheckBox chkProfile = item.FindControl("chkProfile") as CheckBox;
                    if (chkProfile.Checked)
                        result.Add(Convert.ToInt32(chkProfile.Attributes["AccountID"]));
                }
            }
            return result;
        }

        protected void lbBack_Click(object sender, EventArgs e)
        {
            _presenter.Back();
        }
    }
}