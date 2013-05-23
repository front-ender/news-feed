using System;
using System.IO;
using System.Net;
using System.Threading;
using newsfeed.Configuration;
using newsfeed.RssFeed;

namespace newsfeed.Listener
{
    /// <summary>
    /// Listener class
    /// TODO: Considered making this IDisposable
    /// </summary>
    public class NewsfeedListener :IDisposable
    {
        readonly HttpListener _uriListener;

        const string QueryStringConst = "uri";

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsfeedListener"/> class.
        /// </summary>
        /// <param name="proxyConfig"></param>
        /// <see cref="IProxyConfig"/>
        public NewsfeedListener(IProxyConfig proxyConfig)
        {
            ThreadPool.SetMaxThreads(50, 1000);
            ThreadPool.SetMinThreads(50, 50);
            _uriListener = new HttpListener();

            string uriPortCombined = proxyConfig.Uri + proxyConfig.PortNumber;
            _uriListener.Prefixes.Add(uriPortCombined);
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            _uriListener.Start();
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

        /// <summary>
        /// Processes the request.
        /// </summary>
        /// <param name="listenerContext">The listener context.</param>
        static void ProcessRequest(object listenerContext)
        {
            try
            {
                var context = (HttpListenerContext)listenerContext;

                var uri = context.Request.QueryString[QueryStringConst];

                byte[] rssFeed = new RssWebClient().Request(uri);
                using (MemoryStream rssFeedMemory = new MemoryStream(rssFeed))
                {
                    rssFeedMemory.WriteTo(context.Response.OutputStream);
                }
                // b4 framework 4.0
//                StreamHelper.CopyStream(rssFeedMemory, context.Response.OutputStream);
             
            }
            catch (Exception ex) { Console.WriteLine("Request error: " + ex); }
        }

        public void Dispose()
        {
               // Dispose of any memory streams and local resources here..
        }
    }
}