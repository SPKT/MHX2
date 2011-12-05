using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;

namespace SPKTWeb.Profiles.UserControls
{
    public partial class ProfileAttributeControlFull : System.Web.UI.UserControl
    {
        public List<ProfileAttributeType> _listProfileAttributeType;
        public ProfileAttributeType _ProfileAttributeType;
        public Profile _profile;
        public IProfileAttributeRepository _Repository;        

        public ProfileAttributeControlFull(Profile profile,List<ProfileAttributeType> listProfileAttributeType)
        {
            _listProfileAttributeType = listProfileAttributeType;
            _profile = profile;
            _Repository = new ProfileAttributeRepository();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ProfileAttribute> listAttribute = new List<ProfileAttribute>();
            listAttribute = _Repository.GetProfileAttributesByProfileID(_profile.ProfileID);
            System.Web.UI.HtmlControls.HtmlGenericControl br = new System.Web.UI.HtmlControls.HtmlGenericControl("br");
            this.Controls.Add(br);
            foreach (ProfileAttribute proAttribute in listAttribute)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl brTab = new System.Web.UI.HtmlControls.HtmlGenericControl("br");
                Label lbl = new Label();
                lbl.Width = 150;
                lbl.Height = 18;
                lbl.ForeColor = System.Drawing.Color.Blue;
                lbl.ID = "lbl"+proAttribute.ProfileAttributeID.ToString();
                lbl.Text = proAttribute.ProfileAttributeName;
                TextBox txt = new TextBox();
                txt.Width = 150;
                txt.Height = 18;
                lbl.ForeColor = System.Drawing.Color.CornflowerBlue;
                txt.ID = "txt" + proAttribute.ProfileAttributeID.ToString();
                txt.Text = proAttribute.Response;
                this.Controls.Add(lbl);
                this.Controls.Add(txt);
                this.Controls.Add(brTab);
                
            }

        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {

        }
    }
}