using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPKTWeb.Profiles.Interface
{
    public interface IUploadAvatar
    {
        void ShowUploadPanel();

        void ShowApprovePanel();

        void ShowMessage(string p);

        void ShowCropPanel();
    }
}
