using System.Collections.Specialized;
using System.IO;
using System.Security.Principal;
using System.Web;
using System.Web.Hosting;
using Rhino.Mocks;

namespace newsfeed.test.Listener
{
    public class HttpContextRhinoMocker
    {
        private readonly HttpContextBase _httpContext;
        public HttpContextBase HttpContext { get { return this._httpContext; } }
        private readonly HttpRequestBase _httpRequest;
        private readonly HttpResponseBase _httpResponse;
        private readonly HttpSessionStateBase _httpSession;
        private readonly HttpServerUtilityBase _httpServer;
        private readonly IPrincipal _userPrincipal;
        private readonly IIdentity _userIdentity;

        readonly NameValueCollection _serverVariables = new NameValueCollection();

        public HttpContextRhinoMocker()
        {
            SimpleWorkerRequest request = new SimpleWorkerRequest("/dummy", @"c:\inetpub\wwwroot\cetrea\newsfeed", "dummy.html", null, new StringWriter());
            HttpContext context = new HttpContext(request);
            //_serverVariables.Add("", "");

            _httpContext = MockRepository.GenerateMock<HttpContextBase>();
            _httpRequest = MockRepository.GenerateMock<HttpRequestBase>();
            _httpResponse = MockRepository.GenerateMock<HttpResponseBase>();
            _httpSession = MockRepository.GenerateMock<HttpSessionStateBase>();
            _httpServer = MockRepository.GenerateMock<HttpServerUtilityBase>();
            _userPrincipal = MockRepository.GenerateMock<IPrincipal>();
            _userIdentity = MockRepository.GenerateMock<IIdentity>();

            _httpContext.Stub(x => x.Request).Return(_httpRequest);
            _httpContext.Stub(x => x.Response).Return(_httpResponse);
            _httpContext.Stub(x => x.Cache).Return(context.Cache);
            _httpContext.Stub(x => x.Session).Return(_httpSession);
            _httpContext.Stub(x => x.Server).Return(_httpServer);
            _httpContext.Stub(x => x.User).Return(_userPrincipal);

            _userPrincipal.Stub(x => x.Identity).Return(_userIdentity);
            _userIdentity.Stub(x => x.Name).Return("guest");

            _httpRequest.Stub(x => x.ServerVariables).Return(_serverVariables);
            _httpRequest.Stub(x => x.ApplicationPath).Return("/newsfeed");
            //ApplicationConfigHolder.HttpContextBase = _httpContext;
        }
    }
}