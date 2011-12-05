using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Domain;
using SPKTCore.Core.DataAccess;

namespace SPKTWeb.Profiles.UserControls
{
    public partial class ProfileAttributeControl : System.Web.UI.UserControl
    {
        public List<ProfileAttribute> _ProfileAttribute;
        public ProfileAttributeType _ProfileAttributeType;
        public Profile _profile;
        public IProfileAttributeRepository _Repository;        

        public ProfileAttributeControl(Profile pro,ProfileAttributeType proAttrType, IProfileAttributeRepository repository)
        {
            _profile = pro;
            _ProfileAttributeType = proAttrType;
            _Repository = repository;
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlAttrtype = new Panel();
            pnlAttrtype.ID = "pnl" + _ProfileAttributeType.Type;
            lblAtriTypeName = new Label();
            System.Web.UI.HtmlControls.HtmlGenericControl br = new System.Web.UI.HtmlControls.HtmlGenericControl("br");       
            lblAtriTypeName.Text = _ProfileAttributeType.Type;
            pnlAttrtype.Controls.Add(lblAtriTypeName);
            pnlAttrtype.Controls.Add(br);
            this.Controls.Add(pnlAttrtype);
            _ProfileAttribute = _Repository.GetProfileAttributesByProfileIDAndType(_profile.ProfileID, _ProfileAttributeType.ProfileAttributeTypeID);
            foreach (ProfileAttribute attribute in _ProfileAttribute)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl brTab = new System.Web.UI.HtmlControls.HtmlGenericControl("br");
                Label label = new Label();
                label.Width = 200;
                label.Height = 20;
                label.ID = "lbl" + attribute.ProfileAttributeName;
                label.Text = attribute.ProfileAttributeName;
                TextBox textbox = new TextBox();
                textbox.Width = 250;
                textbox.Height = 20;
                textbox.ID = "txt" + attribute.ProfileAttributeName;
                textbox.Text = attribute.Response;
                pnlAttrtype.Controls.Add(label);
                pnlAttrtype.Controls.Add(textbox);
                pnlAttrtype.Controls.Add(brTab);
            }
        }
    }
}