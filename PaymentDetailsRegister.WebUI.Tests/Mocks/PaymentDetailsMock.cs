using HttpMock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.Tests.Helpers;
using WebUI.Tests.Models;

namespace WebUI.Tests.Mocks
{
    public class PaymentDetailsMock
    {
        private const string endpoint = "/api/PaymentDetails";

        private StubServer stubHttp;

        public PaymentDetailsMock()
        {
            stubHttp = new StubServer();
        }               

        /// <summary>
        /// Setup POST for Payment Details. 
        /// </summary>
        public void SetupPost(string response)
        {
            stubHttp.SetupPost(endpoint, response);                
        }

        /// <summary>
        /// Setup OPTIONS for Payment Details. 
        /// </summary>
        public void SetupOptions()
        {
            stubHttp.SetupOptions(endpoint);
        }

        /// <summary>
        /// Check if POST request was received by Payment Details Mock Service at least once
        /// </summary>
        /// <returns></returns>
        public bool IsPostCalled()
        {
            var requestHandler = stubHttp.getHttpStub.GetRequestProcessor().FindHandler("POST", endpoint).LastRequest();
            return requestHandler != null;
        }

        /// <summary>
        /// Get the Payment Details object which was received in the last POST request to the Payment Details Mock Service
        /// </summary>
        /// <returns></returns>
        public PaymentDetail GetLastPaymentPosted()
        {
            var lastRequestBody = stubHttp.getHttpStub.GetRequestProcessor().FindHandler("POST", endpoint)?.LastRequest()?.Body;
            return JsonConvert.DeserializeObject<PaymentDetail>(lastRequestBody);
        }
    }
}
