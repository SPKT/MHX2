using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Profiles.Interface;
using SPKTWeb.Profiles.Presenter;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Profiles
{
    public partial class ViewProfile : System.Web.UI.Page, IViewProfile
    {
        ViewProfilePresenter _presenter;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ViewProfilePresenter();
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
                lblProfileName.Text = profile.profileName;
                TenDayDu.Visible = _presenter.IsAttributeVisible((int)PrivacyFlagType.PrivacyFlagTypes.FullName);
                lblTenThat.Text = profile.FullName;
                NgaySinh.Visible = _presenter.IsAttributeVisible((int)PrivacyFlagType.PrivacyFlagTypes.Birthday);
                lblNgaySinh.Text = profile.Birthday.ToString();
                NgaySinh.Visible = _presenter.IsAttributeVisible((int)PrivacyFlagType.PrivacyFlagTypes.Signature);
                lblChuKy.Text = profile.Signature;
                NgaySinh.Visible = _presenter.IsAttributeVisible((int)PrivacyFlagType.PrivacyFlagTypes.Sex);
                lblSex.Text = profile.Sex;
            }
        }

        public void loadProfileAttribute(List<ProfileAttributeType> profileAttributeType, Profile profile)
        {

            System.Web.UI.HtmlControls.HtmlGenericControl br = new System.Web.UI.HtmlControls.HtmlGenericControl("br");
            divProfileAttribute.Controls.Add(br);
            foreach(ProfileAttributeType type in profileAttributeType)
            {
                if (_presenter.IsAttributeVisible((int)type.PrivacyFlagTypeID))
                {
                    System.Web.UI.HtmlControls.HtmlGenericControl brTab = new System.Web.UI.HtmlControls.HtmlGenericControl("br");

                    ProfileAttribute attribute = _presenter.GetProfileAttributeByProfileIDAndType(profile, type);
                    if (attribute == null)
                    {
                        attribute = new ProfileAttribute();
                        attribute.ProfileID = profile.ProfileID;
                        attribute.ProfileAttributeName = type.Type;
                        attribute.ProfileAttributeTypeID = type.ProfileAttributeTypeID;

                    }
                    divProfileAttribute.Controls.Add(new LiteralControl("<div class=\"divContainerTitle\">"));
                    divProfileAttribute.Controls.Add(new LiteralControl(type.Type));
                    divProfileAttribute.Controls.Add(new LiteralControl("<div class=\"divContainerRow\">"));
                    divProfileAttribute.Controls.Add(new LiteralControl(attribute.Response));
                    divProfileAttribute.Controls.Add(new LiteralControl("</div></div>"));

                }
            }
        }

        public void DisplayAccountInfo(int viewerID, int accountID)
        {
            imgAvatar.Src = "~/Image/ProfileAvatar.aspx?AccountID=" + accountID.ToString();

            lnkChangeAvatar.Visible = (viewerID == accountID);
            lnkManageProfile.Visible=(viewerID == accountID);
            if (lnkChangeAvatar.Visible == true)
                lblDisplayProfileName.Visible = false;
            else
                lblDisplayProfileName.Visible = true;
        }
        public void ShowProfileName(string profileName)
        {
            lblDisplayProfileName.Text = profileName;
        }

        public void lbtnChangeAvatar_Click(object sender, EventArgs e)
        {
            _presenter.GotoUpdateAvatar();
        }
    }
    
}