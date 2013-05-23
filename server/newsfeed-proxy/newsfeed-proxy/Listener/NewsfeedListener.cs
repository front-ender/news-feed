using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace newsfeed_proxy.Listener
{
    /// <summary>
    /// 
    /// </summary>
    class NewsfeedListener
    {
        readonly HttpListener _uriListener;
        readonly string _baseFolder;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsfeedListener"/> class.
        /// </summary>
        /// <param name="uriPrefix">The URI prefix.</param>
        /// <param name="baseFolder">The base folder.</param>
        public NewsfeedListener(string uriPrefix, string baseFolder)
        {
            ThreadPool.SetMaxThreads(50, 1000);
            ThreadPool.SetMinThreads(50, 50);
            _uriListener = new HttpListener();
            _uriListener.Prefixes.Add(uriPrefix);
            _baseFolder = baseFolder;
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
        void ProcessRequest(object listenerContext)
        {
            try
            {
                var context = (HttpListenerContext)listenerContext;
                string filename = Path.GetFileName(context.Request.RawUrl);
                string path = Path.Combine(_baseFolder, filename);
                byte[] msg;
                if (!File.Exists(path))
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    msg = Encoding.UTF8.GetBytes("Sorry, that page does not exist");
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    msg = File.ReadAllBytes(path);
                    // TODO: Stream reader for RSS
                    //using (Stream stream = webClient.OpenRead(url))
                    //{
                    //    using (StreamReader streamReader = new StreamReader(stream))
                    //    {
                    //        return streamReader.ReadToEnd();
                    //    }
                    //}

                }
                context.Response.ContentLength64 = msg.Length;
                using (StreamWriter s = new StreamWriter(context.Response.OutputStream))
                {
                    // TODO: Stream write for embedding resource
                    s.WriteLine("<P>Hello, {0}</P>", "URI OR SOMETHING");
//                    s.Write(msg, 0, msg.Length);
                }
            }
            catch (Exception ex) { Console.WriteLine("Request error: " + ex); }
        }
    }
}