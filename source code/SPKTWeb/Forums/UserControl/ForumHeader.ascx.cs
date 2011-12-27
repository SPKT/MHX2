using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPKTWeb.Forums.UserControl
{
    public partial class ForumHeader : System.Web.UI.UserControl
    {
        public Label lblForumCreateDate
        {
            get { return lblCreateDate; }
            set { lblCreateDate = value; }
        }
        public Label lblForumName
        {
            get { return lblTen; }
            set { lblTen = value; }
        }
        public Label lblForumPostCount
        {
            get { return lblPostCount; }
            set { lblPostCount = value; }
        }
        public HyperLink hlkTatCaBaiViet
        {
            get { return alkTatCaBaiViet; }
            set { alkTatCaBaiViet = value; }
        }
        public HyperLink hlkBaiVietMoiNhat
        {
            get { return alkBaiVietGanNhat; }
            set { alkBaiVietGanNhat = value; }
        }
        public HyperLink hlkDangBaiMoi
        {
            get { return alkDangBaiMoi; }
            set { alkDangBaiMoi = value; }
        }
        public HyperLink hlkBaiVietQuanTrong
        {
            get { return alkQuanTrong; }
            set { alkQuanTrong = value; }
        }
        public HyperLink hlkXemNhieuNhat
        {
            get { return alkXemNhieuNhat; }
            set { alkXemNhieuNhat = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {            
        }

        public void LoadForum()
        { 
        
        }

        public void LoadForum(SPKTCore.Core.Domain.BoardForum forum)
        {
            lblForumName.Text = forum.Name;
            lblCreateDate.Text = forum.CreateDate.ToLongDateString();
            lblPostCount.Text = forum.PostCount.ToString();
            hlkTatCaBaiViet.NavigateUrl = "/Forums/ViewForum1.aspx?ForumID=" + forum.ForumID.ToString();
            hlkDangBaiMoi.NavigateUrl = "/Forums/Post.aspx?IsThread=1&ForumID=" + forum.ForumID.ToString();
        }
    }
}