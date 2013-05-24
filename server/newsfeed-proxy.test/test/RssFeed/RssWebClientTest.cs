using System.IO;
using newsfeed.RssFeed;
using NUnit.Framework;

namespace newsfeed.test.RssFeed
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

        private const string Top10Apps = "https://itunes.apple.com/us/rss/topfreeapplications/limit=10/xml?partnerId=2003&tduid=6b2289862430bb7d4d58efd58bd7dd6e";

        [Test]
        public void ReadTop10AppsFeedFromApple()
        {
            // Do test here..
            byte [] appleTop10 = _rssWebClient.Request(Top10Apps);

            using (FileStream fs = new FileStream("apple.xml", FileMode.CreateNew))
            {
                using (MemoryStream rssFeedMemory = new MemoryStream(appleTop10))
                {
                    rssFeedMemory.WriteTo(fs);
                }
            }

            using (FileStream fs = new FileStream("apple.xml", FileMode.Open))
            {
                Assert.AreEqual(appleTop10.Length, fs.Length);
                foreach (byte b in appleTop10)
                {
                    Assert.AreEqual(b, fs.ReadByte());
                }
            }
        }           
    }
}