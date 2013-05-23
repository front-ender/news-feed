using System;
using System.ServiceProcess;
using newsfeed.Configuration;
using newsfeed.Listener;

namespace newsfeed.service
{
    public partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                new NewsfeedListener(NewsfeedConfig.Uri, NewsfeedConfig.PortNumber);

            }
            catch (Exception)
            {
                // TODO : Write to log in case of configuration error or set up issues..                
                throw;
            }
        }

        protected override void OnStop()
        {
        }
    }
}
