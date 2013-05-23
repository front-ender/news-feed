using System.Web;
using NUnit.Framework;

namespace newsfeed.test.Listener
{
    public class TestBase
    {
        public HttpContextBase HttpContext { get { HttpContextWrapper context = new HttpContextWrapper(System.Web.HttpContext.Current); return context; } }
        protected readonly HttpContextRhinoMocker Mocker = new HttpContextRhinoMocker();


        public virtual void Setup()
        {
            Assert.IsNotNull(Mocker);
            Assert.IsNotNull(Mocker.HttpContext);
            Assert.IsNotNull(Mocker.HttpContext.Server);
//            Assert.AreEqual(1, Mocker.HttpContext.Request.ServerVariables.Count);
        }
    }
}