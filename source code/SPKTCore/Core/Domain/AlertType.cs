using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPKTCore.Core.Domain
{
    public partial class AlertType
    {
        public enum AlertTypes
        {
           
            ProfileModified = 1,
            NewAvatar = 2,
            AddedFriend = 3,
            AddedPicture = 4, 
            FriendAdded=5,
            FriendRequest=6,
            StatusUpdate=7,
            UpdateBlogPost=8,
            ProfileCreated = 9,
            CreatedBlog=10,
            AccountCreated=11,
            AccountModified=12,
            NewBoardPost=13,
            NewBoardThread=14,
            NewBlogPost=15,
            Comment
        }
    }
}
