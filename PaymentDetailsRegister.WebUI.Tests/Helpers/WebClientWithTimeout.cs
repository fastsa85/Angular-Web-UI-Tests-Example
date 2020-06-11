using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Tests.Helpers
{
    public class WebClientWithTimeout : WebClient
    {
        /// <summary>
        /// Timeout duration.
        /// </summary>
        public int Timeout { get; set; }

        /// <inheritdoc cref="WebClient"/>
        protected override WebRequest GetWebRequest(Uri uri)
        {
            var w = base.GetWebRequest(uri);
            if (w != null) w.Timeout = Timeout;
            return w;
        }
    }
}
