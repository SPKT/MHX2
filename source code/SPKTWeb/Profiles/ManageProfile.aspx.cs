using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Profiles.Interface;
using SPKTCore.Core.Domain;
using SPKTWeb.Profiles.Presenter;
using SPKTWeb.Profiles.UserControls;

namespace SPKTWeb.Profiles
{
    public partial class ManageProfile : System.Web.UI.Page, IManageProfile
    {
        ManageProfilePresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ManageProfilePresenter();
            _presenter.Init(this, IsPostBack);
        }

        public void ShowMessage(string Message)
        {
            lblError.Text = Message;
        }

        public void LoadLevelOfExperienceTypes(List<LevelOfExperience> types)
        {
            throw new NotImplementedException();
        }

        public void LoadProfile(Profile profile, List<VisibilityLevel> ListVisibilityLevel)
        {
            if (profile != null)
            {
                txtProfileName.Text = profile.profileName;
                txtTenThat.Text = profile.FullName;
                txtNgaySinh.Text = profile.Birthday.ToString();
                txtChuKy.Text = profile.Signature;
                txtSex.Text = profile.Sex;
                foreach (VisibilityLevel level in ListVisibilityLevel)
                {
                    ListItem li = new ListItem(level.Name, level.VisibilityLevelID.ToString());
                    if (!IsPostBack)
                    {
                        li.Selected = _presenter.IsFlagSelected(1, level.VisibilityLevelID, _presenter.GetPrivacyFlag());
                    }
                    ddlVisibility1.Items.Add(li);

                }
                foreach (VisibilityLevel level in ListVisibilityLevel)
                {
                    ListItem li = new ListItem(level.Name, level.VisibilityLevelID.ToString());
                    if (!IsPostBack)
                    {
                        li.Selected = _presenter.IsFlagSelected(2, level.VisibilityLevelID, _presenter.GetPrivacyFlag());
                 
                    }
                 
                    ddlVisibility2.Items.Add(li);
                
                }
                foreach (VisibilityLevel level in ListVisibilityLevel)
                {
                    ListItem li = new ListItem(level.Name, level.VisibilityLevelID.ToString());
                    if (!IsPostBack)
                    {
                         li.Selected = _presenter.IsFlagSelected(3, level.VisibilityLevelID, _presenter.GetPrivacyFlag());
                      
                    }
                    ddlVisibility3.Items.Add(li);
                }
                foreach (VisibilityLevel level in ListVisibilityLevel)
                {
                    ListItem li = new ListItem(level.Name, level.VisibilityLevelID.ToString());
                    if (!IsPostBack)
                    {
                         li.Selected = _presenter.IsFlagSelected(4, level.VisibilityLevelID, _presenter.GetPrivacyFlag());
                    }
                    ddlVisibility4.Items.Add(li);
                }

            }
        }

        public void loadProfileAttribute(List<ProfileAttributeType> profileAttributeType,List<VisibilityLevel> ListVisibilityLevel,List<PrivacyFlag> PrivacyFlags, Profile profile)
        {
            #region MyRegion
            //foreach (ProfileAttributeType pt in profileAttributeType)
            //{
            //    ProfileAttributeControl ctr = new ProfileAttributeControl(profile, pt, _presenter._profileAttributeRepository);
            //    ProfileAttribute.Controls.Add(ctr);
            //}
            /* ProfileAttributeControlFull ctr = new ProfileAttributeControlFull(profile, profileAttributeType);
             ProfileAttribute.Controls.Add(ctr);*/
            //SPKTCore.Core.DataAccess.IProfileAttributeRepository _Repository = new SPKTCore.Core.DataAccess.Impl.ProfileAttributeRepository();
            // List<ProfileAttribute> listAttribute = new List<ProfileAttribute>();
            // listAttribute = _Repository.GetProfileAttributesByProfileID(profile.ProfileID);
            // if (listAttribute.Count != profileAttributeType.Count)
            // {
            //     _presenter.AddProfileAttribute(profileAttributeType, profile);
            // }
            // System.Web.UI.HtmlControls.HtmlGenericControl br = new System.Web.UI.HtmlControls.HtmlGenericControl("br");
            // ProfileAttribute.Controls.Add(br);
            // foreach (ProfileAttribute proAttribute in listAttribute)
            // {
            //     System.Web.UI.HtmlControls.HtmlGenericControl brTab = new System.Web.UI.HtmlControls.HtmlGenericControl("br");
            //     Label lbl = new Label();
            //     lbl.Width = 150;
            //     lbl.Height = 18;
            //     lbl.ForeColor = System.Drawing.Color.Blue;
            //     lbl.ID = "lbl" + proAttribute.ProfileAttributeID.ToString();
            //     lbl.Text = proAttribute.ProfileAttributeName;
            //     TextBox txt = new TextBox();
            //     txt.Width = 150;
            //     txt.Height = 18;
            //     lbl.ForeColor = System.Drawing.Color.CornflowerBlue;
            //     txt.ID = "txt" + proAttribute.ProfileAttributeID.ToString();
            //     txt.Text = proAttribute.Response;
            //     ProfileAttribute.Controls.Add(lbl);
            //     ProfileAttribute.Controls.Add(txt);
            //     ProfileAttribute.Controls.Add(brTab); 
            #endregion

            
            System.Web.UI.HtmlControls.HtmlGenericControl br = new System.Web.UI.HtmlControls.HtmlGenericControl("br");
            divProfileAttribute.Controls.Add(br);
            foreach(ProfileAttributeType type in profileAttributeType)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl brTab = new System.Web.UI.HtmlControls.HtmlGenericControl("br");
                Label lbl = new Label();
                lbl.Width = 150;
                lbl.ForeColor = System.Drawing.Color.Blue;
                lbl.ID = "lbl" + type.ProfileAttributeTypeID.ToString();
                lbl.Text = type.Type;
                TextBox txt = new TextBox();
                txt.Width = 150;
                lbl.ForeColor = System.Drawing.Color.CornflowerBlue;
                DropDownList ddlVisibility = new DropDownList();
                ddlVisibility.ID = "ddlVisibility" + type.PrivacyFlagTypeID.ToString();
                foreach (VisibilityLevel level in ListVisibilityLevel)
                {
                    ListItem li = new ListItem(level.Name, level.VisibilityLevelID.ToString());
                    if (!IsPostBack)
                        li.Selected = _presenter.IsFlagSelected((int)type.PrivacyFlagTypeID, level.VisibilityLevelID, PrivacyFlags);
                    ddlVisibility.Items.Add(li);
                }
                ProfileAttribute attribute = _presenter.GetProfileAttributeByProfileIDAndType(profile,type);
                if(attribute==null)
                 {
                    attribute = new ProfileAttribute();
                    attribute.ProfileID = profile.ProfileID;
                    attribute.ProfileAttributeName = type.Type;
                    attribute.ProfileAttributeTypeID = type.ProfileAttributeTypeID;
                    _presenter.SaveAttribute(attribute);
                 };
                divProfileAttribute.Controls.Add(lbl);
                divProfileAttribute.Controls.Add(txt);
                divProfileAttribute.Controls.Add(ddlVisibility);
                divProfileAttribute.Controls.Add(brTab);
                txt.ID = "txt" + attribute.ProfileAttributeID.ToString();
                txt.Text = attribute.Response;
            }
        }
        protected void btnSaveProfile_Click(object sender, EventArgs e)
        {
                Profile profile;
                profile = _presenter.GetProfile();
                profile.FullName = txtTenThat.Text;
               // profile.Birthday = DateTime.Parse(txtNgaySinh.Text);
                profile.Birthday = Convert.ToDateTime(txtNgaySinh.Text);
                profile.Sex = txtSex.Text;
                profile.Signature = txtChuKy.Text;
                profile.profileName = txtProfileName.Text;
                profile.Attributes = ExtractAttributes(profile);
                foreach (PrivacyFlagType type in _presenter.GetPrivacyFlagTypes())
                {

                        DropDownList ddlVisibility =
                            divProfileAttribute.FindControl("ddlVisibility" + type.PrivacyFlagTypeID.ToString()) as DropDownList;
                        if (ddlVisibility != null)
                            _presenter.SavePrivacyFlag(type.PrivacyFlagTypeID, Convert.ToInt32(ddlVisibility.SelectedValue));
                    
                }
                _presenter.SaveProfile(profile);
            

        }
        private List<ProfileAttribute> ExtractAttributes(Profile profile)
        {
            List<ProfileAttribute> Attributes = new List<ProfileAttribute>();
            foreach (ProfileAttribute attribute in _presenter.GetProfileAttributeByProfileID(profile))
            {
                TextBox txtProfileAttribute = divProfileAttribute.FindControl("txt" + attribute.ProfileAttributeID.ToString()) as TextBox;
                if (txtProfileAttribute != null)
                {
                    txtProfileAttribute.ID = "txt" + attribute.ProfileAttributeID.ToString();
                    attribute.Response = txtProfileAttribute.Text;
                    Attributes.Add(attribute);
                }
                
            }
            return Attributes;
        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            btnSaveProfile_Click(sender, e);
        }


        public void ShowProfileName(string profileName)
        {
            //lblProfileName.Text = profileName;
        }

        public void lbtnChangeAvatar_Click(object sender, EventArgs e)
        {
            _presenter.GotoUpdateAvatar();
        }

        protected void lbt_DSBB_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Friends/ShowFriend.aspx");
        }
    }
}