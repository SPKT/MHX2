using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Interface
{
    public interface IComments
    {
        int SystemObjectID { get; set; }
        long SystemObjectRecordID { get; set; }
        void ShowCommentBox(bool IsVisible);
        void LoadComments(List<Comment> comments);
        void ClearComments();
    }
}