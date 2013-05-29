using System;
using System.Globalization;
using newsfeed.Configuration;

namespace newsfeed.Helper
{
    public class UriHelper
    {

        private static Uri SetPort(Uri uri, int newPort)
        {
            return new UriBuilder(uri) { Port = newPort }.Uri;
        }

        public static string CalculateCombinedPath(IProxyConfig proxyConfig)
        {
            int portNumber;
            int.TryParse(proxyConfig.PortNumber, NumberStyles.Integer, CultureInfo.InvariantCulture, out portNumber);

            string uriPortCombined;
            //"http://www.contoso.com:8080/customerData/"
            if (!string.IsNullOrEmpty(proxyConfig.Uri))
            {
                Uri uri = new Uri(proxyConfig.Uri);
                uriPortCombined = portNumber != 0 ? SetPort(uri, portNumber).OriginalString : proxyConfig.Uri;
            }
            else if (!string.IsNullOrEmpty(proxyConfig.PortNumber))
            {
                uriPortCombined = string.Format("http://*:{0}/", proxyConfig.PortNumber);
            }
            else
            {
                uriPortCombined = "http://*/";
            }
            return uriPortCombined;
        }
    }
}