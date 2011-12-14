using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Groups.Interface
{
    public interface IViewGroup
    {
        void LoadData(Group group, List<Account> accounts);
        void ShowMessage(string Message);
        void ShowPublic(bool Visible);
        void ShowPrivate(bool Visible);
        void ShowRequestMembership(bool Visible);



        void LoadForum(BoardForum forum, List<BoardPost> threads, BoardCategory category, Group group);
    }
}