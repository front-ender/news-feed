using NUnit.Framework;
using newsfeed.Listener;

namespace newsfeed.test.Listener
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class NewsfeedListenerTest
    {
        private const string UriCetrea = "http://cetrea.dk/";

        private  NewsfeedListener _newsfeedListener = new NewsfeedListener(UriCetrea, string.Empty);
        [SetUp]
        public void Setup()
        {
            
        }


        [Test]
        public void TestExampleOne()
        {
            // Do test here..

        }        
    }
}