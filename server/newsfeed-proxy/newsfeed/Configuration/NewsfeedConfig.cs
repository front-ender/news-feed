using System.Web.Configuration;

namespace newsfeed.Configuration
{
    public class NewsfeedConfig
    {
        public NewsfeedConfig()
        {
            Uri = WebConfigurationManager.AppSettings["Uri"];
            PortNumber = WebConfigurationManager.AppSettings["PortNumber"];
        }

        public NewsfeedConfig(string uri, string port)
        {
            Uri = uri;
            PortNumber = port;
        }

        /// <summary>
        /// Gets the proxy config.
        /// </summary>
        /// <value>The proxy config.</value>
        public IProxyConfig ProxyConfig {
            get
            {
                return new ProxyConfig(Uri, PortNumber);
            }
        }

        /// <summary>
        /// Gets or sets the URI.
        /// </summary>
        /// <value>The URI.</value>
        public string Uri
        { 
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the port number.
        /// Typically port 8080 on IIS
        /// </summary>
        /// <value>The port number.</value>
        public string PortNumber
        {
            get;
            private set;
        }
    }
}