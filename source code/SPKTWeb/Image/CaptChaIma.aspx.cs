using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPKTCore.Core;
using SPKTCore.Core.Impl;
using System.Drawing.Imaging;

namespace SPKTWeb.Image
{
    public partial class CaptChaIma : System.Web.UI.Page
    {
        private Random random = new Random();
        private IWebContext _webContext;

        private void Page_Load(object sender, System.EventArgs e)
        {
            //TODO:StrutureMap
           // _webContext = ObjectFactory.GetInstance<IWebContext>();
            _webContext = new WebContext();
            _webContext.CaptchaImageText = GenerateRandomCode();

            //ICaptcha ci = ObjectFactory.GetInstance<ICaptcha>();
            ICaptcha ci = new Captcha();
            ci.Text = _webContext.CaptchaImageText;
            ci.Width = 150;
            ci.Height =30;
            ci.FamilyName = "Century Schoobook";

            Response.Clear();
            Response.ContentType = "image/jpeg";
            ci.Image.Save(Response.OutputStream, ImageFormat.Jpeg);
            ci.Dispose();
        }

        private string GenerateRandomCode()
        {
            string s = "";
            for (int i = 0; i < 6; i++)
                s = String.Concat(s, this.random.Next(10).ToString());
            return s;
        }

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }
    }
}