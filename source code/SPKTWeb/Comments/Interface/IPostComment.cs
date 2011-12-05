using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Comments.Interface
{
    public interface IPostComment
    {
        int SystemObjectID { get; set; }
        int SystemObjectRecordID { get; set; }
        void ShowCommentBox(bool IsVisible);
        void LoadComments(List<Comment> comments);
        void ClearComments();
    }
}