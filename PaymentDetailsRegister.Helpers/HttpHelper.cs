using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace PaymentDetailsRegister.Helpers
{
    public class HttpHelper
    {
        public void WaitForUrlAlive(string url, int timeout = 60000)
        {
            SpinWait.SpinUntil(() => IsUrlAlive(url), timeout);
        }

        public void WaitForUrlNotAlive(string url, int timeout = 60000)
        {
            SpinWait.SpinUntil(() => !IsUrlAlive(url), timeout);
        }

        public bool IsUrlAlive(string aUrl)
        {
            var request = System.Net.WebRequest.Create(aUrl);
            request.Method = "GET";
            try
            {
                var response = (HttpWebResponse) request.GetResponse();
                return response.StatusCode == HttpStatusCode.OK;
            }
            catch
            {
                return false;
            }
        }
    }
}
