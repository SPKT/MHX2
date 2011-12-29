using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Impl;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Domain;
using SPKTWeb.Interface;

namespace SPKTWeb.Presenter
{
    public class CommentsPresenter
    {
        private IComments _view;
        private ICommentRepository _commentRepository;
        private IWebContext _webContext;
        private IUserSession _userSession;
        private IAlertService _alertService;
        public CommentsPresenter()
        {
            _commentRepository = new CommentRepository();
            _webContext = new WebContext();
            _userSession = new UserSession();
            _alertService = new AlertService();
        }

        public void Init(IComments view, bool IsPostBack)
        {
            _view = view;
            bool IsLogin = _userSession.LoggedIn;
            if (!IsLogin)
            {
                //TODO:Hien thong bao chua dang nhap khong the gui comment
            }
            if (_webContext.CurrentUser != null)
                _view.ShowCommentBox(true);
            else
                _view.ShowCommentBox(false);
        }

        public void LoadComments()
        {

            List<Comment> lstComments = _commentRepository.GetCommentsBySystemObject(_view.SystemObjectID, _view.SystemObjectRecordID);
            _view.ClearComments();
            _view.LoadComments(lstComments);
        }

        public void AddComment(string comment)
        {   

            Comment c = new Comment();
            c.Body = comment;
            c.CommentByAccountID = _webContext.CurrentUser.AccountID;
            c.CommentByUsername = _webContext.CurrentUser.UserName;
            c.CreateDate = DateTime.Now;
            c.SystemObjectID = _view.SystemObjectID;
            c.SystemObjectRecordID = _view.SystemObjectRecordID;
            long kq = _commentRepository.SaveComment(c);
            _alertService.AddComment(c);
            _view.ClearComments();
            LoadComments();
        }
    }
}