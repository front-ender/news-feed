using System.IO;
using System.Net;
using newsfeed.Configuration;
using NUnit.Framework;
using newsfeed.Listener;

namespace newsfeed.test.Listener
{
    /// <summary>
    /// Test for newsfeed listener
    /// </summary>
    [TestFixture]
    public class NewsfeedListenerTest : HttpContextRhinoMocker
    {
        private readonly HttpContextRhinoMocker _mocker = new HttpContextRhinoMocker();
        private const string UriCetrea = "http://cetrea.dk/proxy/";
        private const string PortNumberCetrea = "8080";
        private IProxyConfig _proxyConfig;
        private NewsfeedListener _newsfeedListener;


        [SetUp]
        public void Setup()
        {
            _proxyConfig = new ProxyConfig(UriCetrea, PortNumberCetrea);
            _newsfeedListener = new NewsfeedListener(_proxyConfig);
            _newsfeedListener.Start();
        }


        [Test]
        public void MakeARequest()
        {
            // Do test here..
            string proxyXmlResponse;
            WebClient webClient = new WebClient();
//            string userName = Configuration.Value("FeedUsername");
//            string userPassword = Configuration.Value("FeedPassword");
//            webClient.Credentials = new NetworkCredential(userName, userPassword);
            using (Stream stream = webClient.OpenRead("localhost?uri=hello"))
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    proxyXmlResponse = streamReader.ReadToEnd();
                }
            }
            Assert.IsNotEmpty(proxyXmlResponse);
            Assert.AreEqual(NewsfeedListener.HelloWorldString, proxyXmlResponse);

        }

        [Test]
        public void MockContextHere()
        {
            Assert.IsNotNull(_mocker);
            Assert.IsNotNull(_mocker.HttpContext);
            Assert.IsNotNull(_mocker.HttpContext.Server);

        }
    }    
}