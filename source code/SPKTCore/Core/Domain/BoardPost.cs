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
        IBoardForumRepository _boardforumRepository;
        public int groupID
        {
            get
            {
                _groupRepository = ObjectFactory.GetInstance<IGroupRepository>();
                 return _groupRepository.GetGroupByForumID(this.ForumID).GroupID;
            }
            
        }
        public string categoryName
        {
            get
            {
                _boardforumRepository = ObjectFactory.GetInstance<IBoardForumRepository>();
                return _boardforumRepository.GetForumByID(this.ForumID).Name;
            }

        }
    
    }
}
