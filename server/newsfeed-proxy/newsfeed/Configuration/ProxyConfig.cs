namespace newsfeed.Configuration
{
    public class ProxyConfig : IProxyConfig
    {
        public ProxyConfig(string uri, string portNumber)
        {
            this.Uri = uri;
            this.PortNumber = portNumber;
        }
        public string Uri { get; private set; }
        public string PortNumber { get; private set; }
    }
}