using newsfeed.Configuration;
using NUnit.Framework;

namespace newsfeed.test.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class NewsfeedConfigTest
    {
        private const string UriConfigConst = "http://cetrea.dk/";
        private const string PortConfigConst = "8080";

        [Test]
        public void PortNumberTest()
        {
            Assert.AreEqual(PortConfigConst, new NewsfeedConfig().PortNumber);
        }
        [Test]
        public void UriTest()
        {
            Assert.AreEqual(UriConfigConst, new NewsfeedConfig().Uri);
        }    
    }
}