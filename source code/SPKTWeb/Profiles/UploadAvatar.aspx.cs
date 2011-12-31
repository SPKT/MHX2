using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Profiles.Presenter;
using SPKTWeb.Profiles.Interface;
using SPKTCore.Core;
using SPKTCore.Core.Impl;

namespace SPKTWeb.Profiles
{
    public partial class UploadAvatar : System.Web.UI.Page, IUploadAvatar
    {
        UploadAvatarPresenter _presenter;
        IRedirector _redirector;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new UploadAvatarPresenter();
            _presenter.Init(this);
            _redirector = new Redirector();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (fuAvatarUpload.PostedFile != null || !string.IsNullOrEmpty(fuAvatarUpload.PostedFile.FileName))
            {
                _presenter.UploadFile(fuAvatarUpload.PostedFile);
            }
        }

        public void ShowUploadPanel()
        {
            pnlUpload.Visible = true;
        }

        public void ShowApprovePanel()
        {
            pnlUpload.Visible = true;
        }

        public void ShowMessage(string p)
        {
            Label1.Text = p;
        }

        public void ShowCropPanel()
        {
            pnlUpload.Visible = true;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            //_presenter.CropFile(Convert.ToInt32(x1.Value),
            //Convert.ToInt32(y1.Value),
           // Convert.ToInt32(width.Value),
           // Convert.ToInt32(height.Value));
            _redirector.GoToProfilesProfile();
        }

    }
}