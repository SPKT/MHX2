﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPKTCore.Core.Domain;
using SPKTCore.Core;
using SPKTCore.Core.DataAccess;
using SPKTCore.Core.Impl;
using SPKTCore.Core.DataAccess.Impl;


namespace SPKTWeb.Photo.Interface
{
    public interface IAddFile
    {
        void addfile(File f);
    }
}