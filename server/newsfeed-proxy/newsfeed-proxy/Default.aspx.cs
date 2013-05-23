using System;
using System.Web;

namespace newsfeed_proxy
{

    /// <summary>
    /// Test page - for test purposes only
    /// </summary>
    public partial class Default : System.Web.UI.Page
    {
        const string QueryStringConst = "uri";
        protected void Page_Load(object sender, EventArgs e)
        {

            string queryString = this.Request.QueryString[QueryStringConst];


            HttpUtility.ParseQueryString(queryString);
        }
    }
}
