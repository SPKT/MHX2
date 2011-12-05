using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPKTWeb
{
    public class LogUtil
    {
        static LogUtil instance;
        private LogUtil()
        {            
        }
        public static LogUtil Logger
        {
            get
            {
                if (instance == null)
                    instance = new LogUtil();
                return instance;
            }
        }
        public void Write(String logMessage)
        {
          //  HttpContext.Current.Response.Write(logMessage);
        }
        public void Writeln(String logMessage)
        {
            Write(logMessage+"<br>");
        }
    }
}