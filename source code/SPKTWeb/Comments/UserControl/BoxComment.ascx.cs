using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Comments.Interface;
using SPKTWeb.Comments.Presenter;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Comments.UserControl
{
    public partial class BoxComment : System.Web.UI.UserControl,IPostComment
    {
        public int SystemObjectID { get; set; }
        public int SystemObjectRecordID { get; set; }
        private PostCommentPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new PostCommentPresenter();
            _presenter.Init(this,IsPostBack);
        }

        protected void bt_send_Click(object sender, EventArgs e)
        {
            //pnComment.Visible = true;
            _presenter.AddComment(tb_comment.Text);
            tb_comment.Text = "";
        }
        public void ShowCommentBox(bool IsVisible)
        {
            pnComment.Visible = IsVisible;
        }

        public void ClearComments()
        {
            //phComments.Controls.Clear();
        }

        public void LoadComments(List<Comment> comments)
        {
            if (comments.Count > 0)
            {
                //phComments.Controls.Add(new LiteralControl("<table width=\"100%\">"));
                foreach (Comment comment in comments)
                {
                    //phComments.Controls.Add(new LiteralControl("<tr><td>" + comment.CommentByUsername + " (" + comment.CreateDate.ToShortDateString() + "): " + comment.Body + "</td></tr>"));
                }
                //phComments.Controls.Add(new LiteralControl("</table>"));
            }
        }
    }
}