﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;

namespace SPKTWeb.Forums.Interface
{
    public interface IPost
    {
        void SetDisplay(bool IsThread);
        void SetErrorMessage(string Message);
        void SetData(BoardForum forum, BoardPost thread);
    }
}