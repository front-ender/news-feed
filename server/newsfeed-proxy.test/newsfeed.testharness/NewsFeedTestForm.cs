using System;
using System.Windows.Forms;
using newsfeed.Configuration;
using newsfeed.Listener;

namespace TestHarness.newsfeed
{
    public partial class NewsFeedTestForm : Form
    {
        public NewsFeedTestForm()
        {
            InitializeComponent();
        }

        private void btnStartHttpListener_Click(object sender, EventArgs e)
        {
            IProxyConfig config = new ProxyConfig(this.tbxUri.Text, this.tbxPort.Text);
            new NewsfeedListener(config).Start();
        }
    }
}
