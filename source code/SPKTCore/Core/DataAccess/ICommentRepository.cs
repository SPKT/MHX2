using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Domain;

namespace SPKTCore.Core.DataAccess
{
    public interface ICommentRepository
    {
        Comment GetCommentByID(long CommentID);
        List<Comment> GetCommentsBySystemObject(int SystemObjectID, long SystemObjectRecordID);
        long SaveComment(Comment comment);
        void DeleteComment(Comment comment);
    }
}
