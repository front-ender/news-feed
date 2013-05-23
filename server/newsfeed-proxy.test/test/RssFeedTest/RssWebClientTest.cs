using newsfeed.Listener;
using newsfeed.RssFeed;
using NUnit.Framework;

namespace newsfeed.test.RssFeedTest
{
    /// <summary>
    /// Testing of RssWebClient that gets the feed
    /// </summary>
    [TestFixture]
    public class RssWebClientTest
    {
        readonly RssWebClient _rssWebClient = new RssWebClient();

        [SetUp]
        public void Setup()
        {
            string test = "123";
        }

        private string Top10Apps = "https://itunes.apple.com/us/rss/topfreeapplications/limit=10/xml?partnerId=2003&tduid=6b2289862430bb7d4d58efd58bd7dd6e";
        [Test]
        public void TestExampleOne()
        {
            // Do test here..
            _rssWebClient.Request(Top10Apps);

        }           
    }
}