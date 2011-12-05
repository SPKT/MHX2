using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Profiles.Interface;
using SPKTWeb.Profiles.Presenter;

namespace SPKTWeb.Profiles
{
    public partial class UploadAvatar : System.Web.UI.Page, IUploadAvatar
    {
        UploadAvatarPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new UploadAvatarPresenter();
            _presenter.Init(this);
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
            _presenter.CropFile(Convert.ToInt32(x1.Value),
            Convert.ToInt32(y1.Value),
            Convert.ToInt32(width.Value),
            Convert.ToInt32(height.Value));
        }


    }
}