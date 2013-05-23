using newsfeed.Listener;
using NUnit.Framework;

namespace newsfeed.test.RssFeedTest
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class RssWebClientTest
    {
        private const string UriCetrea = "http://cetrea.dk/";

        private NewsfeedListener _newsfeedListener = new NewsfeedListener(UriCetrea, string.Empty);
        [SetUp]
        public void Setup()
        {
            string test = "123";
        }


        [Test]
        public void TestExampleOne()
        {
            // Do test here..

        }           
    }
}