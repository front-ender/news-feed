using System.Web.Configuration;

namespace newsfeed.Configuration
{
    public class NewsfeedConfig
    {
        public static string Uri
        {
            get
            {
                return WebConfigurationManager.AppSettings["Uri"]; // typlically port 8080 on IIS
            }
        }
        public static string PortNumber
        {
            get
            {
                return WebConfigurationManager.AppSettings["PortNumber"]; // typlically port 8080 on IIS
            }
        }
    }
}