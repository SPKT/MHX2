using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess.Impl;
using SPKTCore.Core.Impl;
using SPKTCore.Core.Domain;
using SPKTWeb.Forums.Interface;

namespace SPKTWeb.Forums.Presenter
{
    public class PostPresenter
    {
        private IPost _view;
        private IBoardPostRepository _postRepository;
        private IBoardForumRepository _forumRepository;
        private IBoardCategoryRepository _categoryRepository;
        private IRedirector _redirector;
        private IWebContext _webContext;
        private IAlertService _alertService;
        private IGroupRepository _groupRepository;
        public PostPresenter()
        {
            _postRepository = new BoardPostRepository();
            _forumRepository = new BoardForumRepository();
            _categoryRepository = new BoardCategoryRepository();
            _redirector = new Redirector();
            _webContext = new WebContext();
            _alertService =new AlertService();
            _groupRepository = new GroupRepository();
        }

        public void Init(IPost View)
        {
            _view = View;
            _view.SetDisplay(_webContext.IsThread);
      
        }

        public void Save(BoardPost post)
        {
            //is new thread
            if (_webContext.LoggedIn)
            {
                post.ReplyByAccountID = _webContext.AccountID;
                post.ReplyByUsername = _webContext.CurrentUser.UserName;
                if (_webContext.ForumID > 0)
                {
                    post.ForumID = _webContext.ForumID;
                    post.IsThread = _webContext.IsThread;
                    if (!_postRepository.CheckPostPageNameIsUnique(post.PageName,post.ForumID))
                    {
                        _view.SetErrorMessage("The page name you are trying to use is already in use!");
                        return;
                    }
                }
                //is reply post
                else
                {
                    BoardPost postToReplyToo = _postRepository.GetPostByID(_webContext.PostID);
                    if (postToReplyToo.IsThread)
                        post.ThreadID = postToReplyToo.PostID;
                    else
                    {
                        post.ThreadID = postToReplyToo.PostID;
                    }

                    post.ForumID = postToReplyToo.ForumID;
                }
                post.CreateDate = DateTime.Now;
                post.UpdateDate = DateTime.Now;
                post.AccountID = _webContext.CurrentUser.AccountID;
                post.Username = _webContext.CurrentUser.UserName;
                post.ReplyCount = 0;
                post.ViewCount = 0;
                if (post.PageName != null)
                    post.PageName = post.PageName.Replace(" ", "-");
                else
                {
                    post.PageName = post.Name;
                    post.PageName = post.PageName.Replace(" ", "-");
                }

                post.PostID = _postRepository.SavePost(post);

                BoardForum forum = _forumRepository.GetForumByID(post.ForumID);
                forum.LastPostByAccountID = post.AccountID;
                forum.LastPostByUsername = post.Username;
                _forumRepository.SaveForum(forum);
                BoardCategory category = _categoryRepository.GetCategoryByCategoryID(forum.CategoryID);
                category.LastPostByAccountID = post.AccountID;
                category.LastPostByUsername = post.Username;
                _categoryRepository.SaveCategory(category);
                BoardPost thread;
                if (post.IsThread)
                    thread = _postRepository.GetPostByID(post.PostID);
                else
                    thread = _postRepository.GetPostByID((long)post.ThreadID);

                //is this forum part of a group?
                Group group = _groupRepository.GetGroupByForumID(forum.ForumID);

                //add an alert to the filter
                if (post.IsThread)
                {
                    //is this a group forum?
                    if (group != null)
                        _alertService.AddNewBoardThreadAlert(category, forum, thread, group);
                    else
                        _alertService.AddNewBoardThreadAlert(category, forum, thread);
                }
                else
                {
                    //is this a group forum?
                    if (group != null)
                        _alertService.AddNewBoardPostAlert(category, forum, post, thread, group);
                    else
                    {
                        _alertService.AddNewBoardPostAlert(category, forum, post, thread);
                        _redirector.GotoViewPostForum(thread.PostID);
                    }
                }
                _redirector.GoToForumsViewPost(forum.PageName, category.PageName, thread.PageName);
            }
            else
                _redirector.GoToAccountLoginPage();
        }
    }
}