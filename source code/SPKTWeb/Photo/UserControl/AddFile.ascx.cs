using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTWeb.Photo.Interface;
using SPKTWeb.Photo.Presenter;

namespace SPKTWeb.Photo.UserControl
{
    public partial class AddFile : System.Web.UI.UserControl
    {
        long idAb;
        long idF;
        SPKTWeb.Photo.Presenter.AddFile add;
        protected void Page_Load(object sender, EventArgs e)
        {
            add = new Presenter.AddFile();
            add.Init();
        }
        public long getidAb()
        {
            return idAb;
        }
        public void setidF(long id)
        {
            idF = id;
        }
        public long getidF()
        {
            return idF;
        }
        public void setidAb(long id)
        {
            idAb = id;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            idF= add.addfile(1,idAb,FileUpload1.PostedFile);
        }
    }
}