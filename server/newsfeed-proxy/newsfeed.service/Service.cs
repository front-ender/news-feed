using System;
using System.ServiceProcess;
using newsfeed.Configuration;
using newsfeed.Listener;

namespace newsfeed.service
{
    public partial class Service : ServiceBase
    {
        private NewsfeedListener _newsFeedListener;
        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                _newsFeedListener = new NewsfeedListener(new NewsfeedConfig().ProxyConfig);
                _newsFeedListener.Start();

            }
            catch (Exception)
            {
                // TODO : Write to log in case of configuration error or set up issues..                
                throw;
            }
        }

        protected override void OnStop()
        {
            _newsFeedListener.Stop();
        }
    }
}
