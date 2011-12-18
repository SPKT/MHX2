using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Impl;
using SPKTCore.Core;
using SPKTWeb.Interface;
using SPKTWeb.Presenter;
namespace SPKTWeb.Profiles.UserControls
{
    public partial class Comment : System.Web.UI.UserControl
    {
        CommentRepository _com;
        AccountRepository _ac;
        private CommentsPresenter _presenter;
        IUserSession _usersession = new UserSession();
        int idac;
        long idst;
        protected void Page_Load(object sender, EventArgs e)
        {
            LogUtil.Logger.Writeln(String.Format(".  -<font color = 'cyan'><u> Comment OnInit:  RecID {0}</u></font>",idst));
            _presenter = new CommentsPresenter();
           // _presenter.Init(this, IsPostBack);
           // _presenter.LoadComments();
            _com = new CommentRepository();
            _ac = new AccountRepository();
            tb_comment.Text = "";
            Image1.ImageUrl ="~/Image/ProfileAvatar.aspx?AccountID=" + _usersession.CurrentUser.AccountID;
            Label1.Text ="Bình luận cho "+ _ac.GetAccountByID(idac).UserName.ToUpper()+" ";
        }
        public void setidac(int accountID)
        {
            idac = accountID;
        }
        public void setidst(long statusID)
        {
            idst = statusID;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SPKTCore.Core.Domain.Comment c = new SPKTCore.Core.Domain.Comment();
            c.Body = tb_comment.Text;
            c.CreateDate = DateTime.Now;
            c.CommentByAccountID = _usersession.CurrentUser.AccountID;
            c.CommentByUsername = _usersession.CurrentUser.UserName;
            c.SystemObjectID = 1;
            c.SystemObjectRecordID = idst;
            _com.SaveComment(c);
                //LogUtil.Logger.Writeln("btnAddComment_Click  cmt: " + tb_comment.Text);
                //_presenter.AddComment1(tb_comment.Text, idst);
                //.Text = "";
        }
        public int SystemObjectID
        {
            get { return 1; }
            set { }
        }
        public long SystemObjectRecordID
        {
            get { return idst; }
            set { idst = value; }
        }
        public void ShowCommentBox(bool IsVisible)
        {
           // pnlComment.Visible = IsVisible;
            throw new NotImplementedException();
        }

        public void ClearComments()
        {
            LogUtil.Logger.Writeln(String.Format(".  - ClearComments ResID: {0}", idst));
        }

        public void LoadComments(List<Comment> comments)
        {
            //throw new NotImplementedException();
            LogUtil.Logger.Writeln(String.Format(".  - LoadComments Count: {0}<br>", comments.Count));
        }
    }
}