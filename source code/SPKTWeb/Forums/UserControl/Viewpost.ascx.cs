using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPKTWeb.Forums.UserControl
{
    public partial class Viewpost : System.Web.UI.UserControl
    {
        public Label lblTilte
        {
            get { return lblSubject; }
            set { lblSubject = value; }
        }
        public Label lblDescript
        {
            get { return lblDescription; }
            set { lblDescription = value; }
        }
        public Label lblCreDate
        {
            get { return lblCreateDate; }
            set { lblCreateDate = value; }
        }
        public Label lblUpdate
        {
            get { return lblUpdateDate; }
            set { lblUpdateDate = value; }
        }
        public HyperLink lkUsername
        {
            get { return linkUsername; }
            set { linkUsername = value; }
        }
        public System.Web.UI.WebControls.Image ImgAvatar 
        {
            get { return imgProfile; }
            set { imgProfile = value; }
        }
        public HyperLink lkReply
        {
            get { return linkReply; }
            set { linkReply = value; }
        }
        public Repeater repPost
        {
            get { return repPosts; }
            set { repPosts = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}