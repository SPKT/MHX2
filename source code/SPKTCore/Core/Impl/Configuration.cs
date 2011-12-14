using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SPKTCore.Core.Impl
{
    public class Configuration:IConfiguration
    {
        public string ToEmailAddress
        {
            get { return (string) getAppSetting(typeof (string), "ToEmailAddress"); }
        }

        public string FromEmailAddress
        {
            get { return (string) getAppSetting(typeof (string), "FromEmailAddress"); }
        }

        public int DefaultCacheDuration_Days
        {
            get { return (int) getAppSetting(typeof (int), "DefaultCacheDuration_Day"); }
        }

        public int DefaultCacheDuration_Hours
        {
            get { return (int)getAppSetting(typeof(int), "DefaultCacheDuration_Hours"); }
        }

        public int DefaultCacheDuration_Minutes
        {
            get { return (int)getAppSetting(typeof(int), "DefaultCacheDuration_Minutes"); }
        }

        public int TagCloudLargestFontSize
        {
            get { return (int)getAppSetting(typeof(int), "TagCloudLargestFontSize"); } 
        }

        public int TagCloudSmallestFontSize
        {
            get { return (int)getAppSetting(typeof(int), "TagCloudSmallestFontSize"); }
        }

        public string CloudSortOrder
        {
            get { return getAppSetting(typeof (string), "CloudSortOrder").ToString(); }
        }

        public int NumberOfTagsInCloud
        {
            get { return (int) getAppSetting(typeof (int), "NumberOfTagsInCloud"); }
        }

        public int NumberOfRecordsInPage
        {
            get { return (int)getAppSetting(typeof(int), "NumberOfRecordsInPage"); }
        }

        public string SiteName
        {
            get{ return getAppSetting(typeof(string),"SiteName").ToString();}
        }
        
        public string WebSiteURL
        {
            get { return getAppSetting(typeof (string), "WebSiteURL").ToString(); }
        }

        public string AdminSiteURL
        {
            get { return getAppSetting(typeof (string), "AdminSiteURL").ToString(); }
        }

        public string RootURL
        {
            get { return getAppSetting(typeof(string), "RootURL").ToString(); }
        }

        private static object getAppSetting(Type expectedType, string key)
        {
            string value = ConfigurationManager.AppSettings.Get(key);
            if (value == null)
            {
                //Log.Fatal("Configuration.cs", string.Format("AppSetting: {0} is not configured", key));
                throw new Exception(string.Format("AppSetting: {0} is not configured.", key));
            }

            try
            {
                if (expectedType.Equals(typeof(int)))
                {
                    return int.Parse(value);
                }

                if (expectedType.Equals(typeof(string)))
                {
                    return value;
                }

                throw new Exception("Type not supported.");
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Config key:{0} was expected to be of type {1} but was not.", key, expectedType),
                                    ex);
            }
        }
    }
    
}
