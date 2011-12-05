using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Domain;
using SPKTWeb.Comments.Interface;

namespace SPKTWeb.Comments.Presenter
{
    public class PostCommentPresenter
    {
        private IPostComment _view;
        private ICommentRepository _commentRepository;
        private IWebContext _webContext;
        private IUserSession _userSession;
        public PostCommentPresenter()
        {
            _commentRepository = new SPKTCore.Core.DataAccess.Impl.CommentRepository();
            _webContext = new SPKTCore.Core.Impl.WebContext();
            _userSession = new SPKTCore.Core.Impl.UserSession();
        }

        public void Init(IPostComment view, bool IsPostBack)
        {
            _view = view;

            if(_userSession.CurrentUser != null)
                _view.ShowCommentBox(true);
            else
                _view.ShowCommentBox(false);
        }

        public void LoadComments()
        {
            _view.LoadComments(_commentRepository.GetCommentsBySystemObject(_view.SystemObjectID,
                                                                             _view.SystemObjectRecordID));    
        }

        public void AddComment(string comment)
        {
            Comment c = new Comment();
            c.Body = comment;
            c.CommentByAccountID = _userSession.CurrentUser.AccountID;
            c.CommentByUsername = _userSession.CurrentUser.UserName;
            c.CreateDate = DateTime.Now;
            c.SystemObjectID = _view.SystemObjectID;
            c.SystemObjectRecordID = _view.SystemObjectRecordID;
            _commentRepository.SaveComment(c);
            _view.ClearComments();
            LoadComments();
        }
    }
}