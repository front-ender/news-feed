using System;
using System.IO;
using System.Net;
using System.Text;

namespace newsfeed.RssFeed
{
    public class RssWebClient
    {
        /// <summary>
        /// Requests the specified URI and returns the response as as an encoded UTF8 byte array
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        public byte[] Request(string uri)
        {
            try
            {
                WebClient webClient = new WebClient();
                // TODO: Need to get clarification on user/password access
                //            string userName = Configuration.Value("FeedUsername");
                //            string userPassword = Configuration.Value("FeedPassword");
                //            webClient.Credentials = new NetworkCredential(userName, userPassword);
                // TODO: Need to get clarification on user/password access
                using (Stream stream = webClient.OpenRead(uri))
                {
                    using (StreamReader streamReader = new StreamReader(stream))
                    {
                        return Encoding.UTF8.GetBytes(streamReader.ReadToEnd());
                    }
                }

            }
            catch (WebException ex)
            {
                if (ex.Response is HttpWebResponse)
                {
                    switch (((HttpWebResponse)ex.Response).StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            return Encoding.UTF8.GetBytes("Sorry, that page does not exist");
                        default:
                            return Encoding.UTF8.GetBytes(ex.Message);
                    }
                }
                return Encoding.UTF8.GetBytes(ex.Message);
            }

        }
    }
}