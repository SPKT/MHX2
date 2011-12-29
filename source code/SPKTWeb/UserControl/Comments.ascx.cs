using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.Domain;
using SPKTWeb.Presenter;
using SPKTWeb.Interface;

namespace SPKTWeb.UserControl
{
    public partial class Comments : System.Web.UI.UserControl, IComments
    {
        public Comments()
        {            
            LogUtil.Logger.Writeln("<font color = 'pink'><u>New Comment</u></font>");
        }
        private CommentsPresenter _presenter;
        public int SystemObjectID {
            get { return int.Parse(hidenSystemObjectID.Value); }
            set { hidenSystemObjectID.Value = value.ToString(); }
        }
        public long SystemObjectRecordID
        {
            get { return int.Parse(hidenSystemObjectRecordID.Value); }
            set { hidenSystemObjectRecordID.Value = value.ToString(); }
        }

        
        protected override void OnInit(EventArgs e)
        {            
            LogUtil.Logger.Writeln(String.Format(".  -<font color = 'cyan'><u> Comment OnInit:  RecID {0}</u></font>",SystemObjectRecordID));
            _presenter = new CommentsPresenter();
            _presenter.Init(this, IsPostBack);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LogUtil.Logger.Writeln(String.Format("<font color='blue' ><i>Comment_Page_Load: ObjID: {0},  RowID: {1}</i></font>" ,SystemObjectID,SystemObjectRecordID));
            _presenter.LoadComments();
        }

        protected void btnAddComment_Click(object sender, EventArgs e)
        {

            LogUtil.Logger.Writeln("btnAddComment_Click  cmt: " + txtComment.Text);
            _presenter.AddComment(txtComment.Text);
            txtComment.Text = "";
        }

        public void ShowCommentBox(bool IsVisible)
        {
            pnlComment.Visible = IsVisible;
        }

        public void ClearComments()
        {
            LogUtil.Logger.Writeln(String.Format(".  - ClearComments ResID: {0}", SystemObjectRecordID));
            phComments.Controls.Clear();
        }

        public void LoadComments(List<Comment> comments)
        {
            if (comments.Count > 0)
            {
                LogUtil.Logger.Writeln(String.Format(".  - LoadComments Count: {0}<br>", comments.Count));
                
                phComments.Controls.Add(new LiteralControl("<table width=\"100%\" boder-color=\"White\" "));
                // String innerHtml="<table width=\"100%\">";
                foreach (Comment comment in comments)
                {
                    phComments.Controls.Add(new LiteralControl("<tr><td>" + " <img width=\"25\" height=\"25\" alt=\"avatar\" src='../image/ProfileAvatar.aspx?AccountID=" + comment.CommentByAccountID + "' align=\"top\" style=\"margin-top: 1px; margin-right: 2px;\" />" + "<a href=\"/Profiles/UserProfile2.aspx?AccountID=" + comment.CommentByAccountID.ToString()+ "\">"
                        + comment.CommentByUsername + "</a> " + ": " +"<a style=\"color:Gray;\">" +  comment.Body+ "</a> "+ "<div>" + "<a style=\"color:#c0c0c0;font-size:smaller; margin-left: 25px\">" + " (" + ((DateTime)(comment.CreateDate)).ToString("dd:MM:yyyy HH:mm:ss") + ")</a>" + "</td></tr>"));
                    //   innerHtml += "<tr><td>" + comment.CommentByUsername + " (" + comment.CreateDate.ToShortDateString() + "): " + comment.Body + "</td></tr>";
                    //   LogUtil.Logger.Writeln(String.Format("      + LoadComments RecID: {0},  ID: {1}<br>", comment.SystemObjectRecordID, comment.CommentID));
                }
                //innerHtml += "</table>";
                //phComments.InnerHtml = innerHtml;
                phComments.Controls.Add(new LiteralControl("</table>"));
            }
            //if (comments.Count > 0)
            //{
            //    gvComment.DataSource = comments;
            //    gvComment.DataBind();
            //}
        }

        protected void pnlComment_DataBinding(object sender, EventArgs e)
        {
            LogUtil.Logger.Writeln(String.Format(".   - Comment_DataBinding: RecID: {0}<br>", SystemObjectRecordID));
            ClearComments();
            _presenter.LoadComments();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            ClearComments();
            _presenter.LoadComments();
        }
    }
}