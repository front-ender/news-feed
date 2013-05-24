using System.IO;
using System.Net;
using NUnit.Framework;

namespace newsfeed.test.Listener
{
    [TestFixture]
    public class IntegrationWebClientTest
    {
        [Test]
        public void MakeARequest()
        {
            // Do test here..
            string test;
            WebClient webClient = new WebClient();
            //            string userName = Configuration.Value("FeedUsername");
            //            string userPassword = Configuration.Value("FeedPassword");
            //            webClient.Credentials = new NetworkCredential(userName, userPassword);
            using (Stream stream = webClient.OpenRead("localhost:8080"))
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    test = streamReader.ReadToEnd();
                }
            }
            Assert.IsNotEmpty(test);

        }
    }
}