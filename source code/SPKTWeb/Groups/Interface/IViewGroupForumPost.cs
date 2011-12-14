using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Groups.Interface
{
    public interface IViewGroupForumPost
    {
        void LoadData(Group group, List<Account> accounts);
        void ShowMessage(string Message);
        void ShowPublic(bool Visible);
        void ShowPrivate(bool Visible);
        void ShowRequestMembership(bool Visible);



        //void LoadForum(BoardForum forum, List<BoardPost> threads, BoardCategory category);

        void LoadDataPost(BoardPost boardPost, List<BoardPost> list, BoardForum forum, Group group);
    }
}