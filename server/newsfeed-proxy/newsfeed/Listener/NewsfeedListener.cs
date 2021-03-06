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
    /// Usage : http://localhost:8080/?uri=hello or
    /// http://localhost:8080/?uri=hello or
    /// http://localhost:8080/?uri=http://bbc.co.uk/news
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
            // TODO: to be removed !!
//            _uriListener.Prefixes.Add("http://+:80/");
//            _uriListener.Prefixes.Add("http://*:8080/");
            // TODO: to be removed !!
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

        public static string ITunesRssFeedString = @"<?xml version=""1.0"" encoding=""UTF-8""?><rss xmlns:itunes=""http://www.itunes.com/dtds/podcast-1.0.dtd"" xmlns:itunesu=""http://www.itunesu.com/feed"" version=""2.0"" ><channel><title>RSS with the best</title><link>http://www.apple.com/</link><language>en-us</language><copyright>℗ &amp; © 2008 Apple</copyright><itunes:subtitle>A podcast series on RSS</itunes:subtitle><itunes:author>Jane Doe</itunes:author><itunes:summary>Creating a well formed RSS feed is important foriTunes U. This weekly series follows the methods to ensure yoursuccess.</itunes:summary><description>Creating a well formed RSS feed is important foriTunes U. This weekly series follows the methods to ensure yoursuccess.</description><itunes:owner><itunes:name>Jane Doe</itunes:name><itunes:email>jdoe@example.com</itunes:email></itunes:owner><itunes:image href=""http://images.apple.com/pr/images/rotation/leopardbox.jpg""/><itunes:explicit>no</itunes:explicit><item><title>XML Basics</title><itunes:author>Jane Doe</itunes:author><itunes:subtitle>A short primer on RSS and XML</itunes:subtitle><itunes:summary>The basics of RSS is XML.  This episode willassist in the development of the RSS shell used for iTunes U RSS feeds.</itunes:summary><enclosure url=""http://example.com/podcasts/RSS-Basics.m4a""length=""234233"" type=""audio/x-m4a""/><guid>http://example.com/podcasts/RSS-Basics.m4a</guid><pubDate>Tue, 17 Jun 2008 19:00:00 GMT</pubDate><itunes:duration>7:04</itunes:duration><itunes:keywords>rss, itunesu, xml, tutorial,training</itunes:keywords></item><item><title>Namespaces Demystified</title><itunes:author>Jane Doe</itunes:author><itunes:subtitle>Understanding how to extend XML throughnamespaces.</itunes:subtitle><itunes:summary>Namespaces allow the extension of RSS to suit theneeds of particular systems.  iTunes U uses a custom namespace too.</itunes:summary><enclosure url=""http://example.com/podcasts/RSS-Namespaces.mp3""length=""289894"" type=""audio/mpeg""/><guid>http://example.com/podcasts/RSS-Namespaces.mp3</guid><pubDate>Wed, 18 Jun 2008 19:00:00 GMT</pubDate><itunes:duration>4:34</itunes:duration><itunes:keywords>xml, namespace, rss, tutorial,training</itunes:keywords></item><item><title>Adding content &amp; keywords</title><itunes:author>Jane Doe</itunes:author><itunes:subtitle>Filling out your RSS feeds.</itunes:subtitle><itunes:summary>Now we have our structure in place, we will additem information and metadata</itunes:summary><enclosure url=""http://example.com/podcasts/RSS-content.mp3""length=""4989537"" type=""audio/mpeg""/><guid>http://example.com/podcasts/RSS-Content.mp3</guid><pubDate>Thu, 19 Jun 2008 19:00:00 GMT</pubDate><itunes:duration>3:59</itunes:duration><itunes:keywords>itunesu, xml, rss, tutorial, training,keywords, item</itunes:keywords></item></channel></rss>";
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

                byte[] rssFeed = uri == SecretUriHelloKeyConst ? System.Text.Encoding.UTF8.GetBytes(HelloWorldString) 
                    : ( uri == "iTunes" ? System.Text.Encoding.UTF8.GetBytes(ITunesRssFeedString) : new RssWebClient().Request(uri));

//                context.Response.ContentType = "text/plain";
//               context.Response.ContentType = "application/vnd.ms-excel";
                // TODO: Consider removing to prevent cross-domain attacks
                context.Response.AddHeader("Access-Control-Allow-Origin", "*");
                // TODO: Consider removing to prevent cross-domain attacks

                using (MemoryStream rssFeedMemory = new MemoryStream(rssFeed))
                {
                    rssFeedMemory.WriteTo(context.Response.OutputStream);
                }

                context.Response.OutputStream.Close();
                context.Response.Close();
                // b4 framework 3.5
//                StreamHelper.CopyStream(rssFeedMemory, context.Response.OutputStream);
             
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Request error: " + ex);
                // Log here
            }
        }

        public void Dispose()
        {
               // Dispose of any memory streams and local resources here..
                ((IDisposable)_uriListener).Dispose();
        }
    }
}