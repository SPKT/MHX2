using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Domain;
using SPKTCore.Core.Impl;
using SPKTWeb.Groups.Presenter;
using SPKTWeb.Groups.Interface;

namespace SPKTWeb.Groups
{
    public partial class ManageGroup : System.Web.UI.Page, IManageGroup
    {
        private ManageGroupPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ManageGroupPresenter();
            _presenter.Init(this, IsPostBack);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Group group = new Group();
            group.GroupID = Convert.ToInt32(litGroupID.Text);
            group.Name = txtName.Text;
            group.Description = txtDescriptionEditor.Content;
            group.PageName = txtName.Text;
            
            group.FileID = Convert.ToInt64(litFileID.Text);
            group.Body = txtBodyEditor.Content;
            group.IsPublic = chkIsPublic.Checked;
            if (group.GroupID > 0)
            {
                group.CreateDate = Convert.ToDateTime(litCreateDate.Text);
                group.UpdateDate = Convert.ToDateTime(litUpdateDate.Text);
                group.AccountID = Convert.ToInt32(litAccountID.Text);
                //group.Timestamp = litTimestamp.Text.StringToTimestamp();
                group.MemberCount = Convert.ToInt32(litMemberCount.Text);
            }

            List<long> selectedGroupTypeIDs = new List<long>();
            foreach (ListItem item in lbGroupTypes.Items)
            {
                if (item.Selected)
                    selectedGroupTypeIDs.Add(Convert.ToInt64(item.Value));
            }
            _presenter.SaveGroup(group, fuLogo.PostedFile, selectedGroupTypeIDs);
        }

        public void ShowMessage(string Message)
        {
            lblMessage.Text = Message;
        }

        public void LoadGroupTypes(List<GroupType> types)
        {
            lbGroupTypes.Items.Clear();
            lbGroupTypes.DataSource = types;
            lbGroupTypes.DataTextField = "Name";
            lbGroupTypes.DataValueField = "GroupTypeID";
            lbGroupTypes.DataBind();
        }

        public void LoadGroup(Group group, List<GroupType> selectedTypes)
        {
           
            txtName.Text = group.Name;
            txtDescriptionEditor.Content = group.Description;
            litGroupID.Text = group.GroupID.ToString();
            litCreateDate.Text = group.CreateDate.ToString();
            litUpdateDate.Text = group.UpdateDate.ToString();
            //litTimestamp.Text = group.Timestamp.TimestampToString();
            litMemberCount.Text = group.MemberCount.ToString();
            litAccountID.Text = group.AccountID.ToString();
            litFileID.Text = group.FileID.ToString();
            imgLogo.ImageUrl = "/files/photos/" + _presenter.GetImagePathByID(group.FileID);
            txtBodyEditor.Content = group.Body;
            chkIsPublic.Checked = group.IsPublic;

            foreach (ListItem item in lbGroupTypes.Items)
            {
                List<long> selectedTypeIDs = selectedTypes.Select(t => t.GroupTypeID).ToList();

                if (selectedTypeIDs.Count == 0)
                    break;

                if (selectedTypeIDs.Contains(Convert.ToInt64(item.Value)))
                    item.Selected = true;
            }
        }
    }
}