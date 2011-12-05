using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPKTCore.Core.Domain
{
    [Serializable]
    public partial class Folder
    {
        public enum Types
        {
            Picture = 1,
            Video = 2,
            Audio = 3,
            File = 4
        }

        public string FullPathToCoverImage { get; set; }
        public string Username { get; set; }
    }
}
