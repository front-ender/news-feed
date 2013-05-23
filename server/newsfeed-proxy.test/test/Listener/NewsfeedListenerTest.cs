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
        private const string UriCetrea = "http://cetrea.dk/";
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
        public void TestExampleOne()
        {
            // Do test here..

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