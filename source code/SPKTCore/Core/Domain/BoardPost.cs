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
        IBoardPostRepository _boardPostRepository;
        public int groupID
        {
            get
            {
                _groupRepository = ObjectFactory.GetInstance<IGroupRepository>();
                 return _groupRepository.GetGroupByForumID(this.ForumID).GroupID;
            }
            
        }
    
    }
}
