using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Forums.Interface
{

    public interface IViewForum
    {
        //void LoadDisplay(List<BoardPost> Threads, string CategoryPageName, string ForumPageName, Int32 ForumID);

        void LoadDisplay(List<BoardPost> list, BoardForum forum);
    }
}