using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.DataAccess.Impl;

namespace SPKTCore.Core.Domain
{
    public partial class BoardPost
    {
        IGroupRepository _groupRepository;
        public int groupID
        {
            get
            {
                 _groupRepository= new GroupRepository();
                 return _groupRepository.GetGroupByForumID(this.ForumID).GroupID;
            }
            
        }
    }
}
