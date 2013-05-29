using System;
using System.IO;
using System.Net;
using newsfeed.Listener;
using NUnit.Framework;

namespace newsfeed.test.Listener
{
    [TestFixture]
    public class IntegrationWebClientTest
    {
        private const string LocalHostUrl="http://localhost";
        private const string LocalHostPort80Url = "http://localhost:80";

        // Need to add these to hosts file in C:\Windows\System32\drivers\etc\hosts
        // 127.0.0.1 	cetrea.dk

        private const string CetreaUrl = "http://dev.cetrea.dk";
        private const string CetreaPort80Url = "http://dev.cetrea.dk:80";

        /// <summary>
        /// Stop listener to make this test succeed
        /// Requests the listener not started.
        /// </summary>
        [Test, Ignore]
        [ExpectedException("File not found")]
        public void RequestListenerNotStarted()
        {
            DoHttpRequest(LocalHostUrl);
        }

        [Test]
        public void LocalHostRequest()
        {
            DoHttpRequest(LocalHostUrl);
        }

        [Test]
        public void LocalHostRequestPort80()
        {
            DoHttpRequest(LocalHostPort80Url);
        }


        [Test]
        public void CetreaRequest()
        {
            DoHttpRequest(CetreaUrl);
        }

        [Test]
        public void CetreaRequestPort80()
        {
            DoHttpRequest(CetreaPort80Url);
        }


        private static void DoHttpRequest(string url)
        {
            string httpProxyResponse;
            WebClient webClient = new WebClient();
            //            string userName = Configuration.Value("FeedUsername");
            //            string userPassword = Configuration.Value("FeedPassword");
            //            webClient.Credentials = new NetworkCredential(userName, userPassword);
            Uri uri = new Uri(string.Format("{0}?uri={1}", url, NewsfeedListener.SecretUriHelloKeyConst));
            using (Stream stream = webClient.OpenRead(uri))
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    httpProxyResponse = streamReader.ReadToEnd();
                }
            }
            Assert.IsNotEmpty(httpProxyResponse);
            Assert.AreEqual(NewsfeedListener.HelloWorldString, httpProxyResponse);
        }
    }
}