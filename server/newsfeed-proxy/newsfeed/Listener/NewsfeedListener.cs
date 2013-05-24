using System;
using System.IO;
using System.Net;
using System.Threading;
using newsfeed.Configuration;
using newsfeed.Helper;
using newsfeed.RssFeed;

namespace newsfeed.Listener
{
    /// <summary>
    /// Listener class
    /// TODO: Considered making this IDisposable
    /// </summary>
    public class NewsfeedListener :IDisposable
    {
        // ref. http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx
        readonly HttpListener _uriListener;

        const string UriQueryStringConst = "uri";
        public const string SecretUriHelloKeyConst = "hello";

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsfeedListener"/> class.
        /// </summary>
        /// <param name="proxyConfig"></param>
        /// <see cref="IProxyConfig"/>
        public NewsfeedListener(IProxyConfig proxyConfig)
        {
            ThreadPool.SetMaxThreads(50, 1000); // TODO: Put in config section
            ThreadPool.SetMinThreads(50, 50);   // TODO: Put in config section
            _uriListener = new HttpListener();
            string prefix = UriHelper.CalculateCombinedPath(proxyConfig);
            _uriListener.Prefixes.Add("http://+:80/");
            _uriListener.Prefixes.Add("http://*:8080/");
            _uriListener.Prefixes.Add(prefix);
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            if (!HttpListener.IsSupported)
            {
                throw new NotSupportedException("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
            }
            try
            {
                _uriListener.Start();
            }
            catch (HttpListenerException exception)
            {
                // TODO Log that a process listening has already started here!!
                // TODO Log that a process listening has already started here!!
                throw;
            }

            while (true)
                try
                {
                    HttpListenerContext request = _uriListener.GetContext();
                    ThreadPool.QueueUserWorkItem(ProcessRequest, request);
                }
                catch (HttpListenerException) { break; }
                catch (InvalidOperationException) { break; }
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            _uriListener.Stop();
        }

        public static string HelloWorldString = "<HTML><BODY> Hello world!</BODY></HTML>";
        

        /// <summary>
        /// Processes the request.
        /// </summary>
        /// <param name="listenerContext">The listener context.</param>
        static void ProcessRequest(object listenerContext)
        {
            try
            {
                var context = (HttpListenerContext)listenerContext;

                string uri = context.Request.QueryString[UriQueryStringConst];

                byte[] rssFeed = uri == SecretUriHelloKeyConst ? System.Text.Encoding.UTF8.GetBytes(HelloWorldString) : new RssWebClient().Request(uri);

                using (MemoryStream rssFeedMemory = new MemoryStream(rssFeed))
                {
                    rssFeedMemory.WriteTo(context.Response.OutputStream);
                }
                context.Response.OutputStream.Close();
                // b4 framework 3.5
//                StreamHelper.CopyStream(rssFeedMemory, context.Response.OutputStream);
             
            }
            catch (Exception ex)
            {
                Console.WriteLine("Request error: " + ex);
            }
        }

        public void Dispose()
        {
               // Dispose of any memory streams and local resources here..
                ((IDisposable)_uriListener).Dispose();
        }
    }
}