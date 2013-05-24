using System;

namespace newsfeed.Helper
{
    public class UriHelper
    {
        public static class UriExtensions
        {
            public static Uri SetPort(Uri uri, int newPort)
            {
                return new UriBuilder(uri) {Port = newPort}.Uri;
            }
        }        
    }
}