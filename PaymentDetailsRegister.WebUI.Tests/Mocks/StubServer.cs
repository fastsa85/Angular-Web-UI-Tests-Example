using HttpMock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.Tests.Helpers;

namespace WebUI.Tests.Mocks
{
    public class StubServer
    {
        private IHttpServer _stubHttp;

        /// <summary>
        /// Initialize the mock server and confirm it is available..
        /// </summary>
        public StubServer()
        {
            const string homePageResponse = "Hello from the mock security api";
            var uri = $"{ConfigurationHelper.MockPaymentDetailsApiHost()}:{ConfigurationHelper.MockPaymentDetailsApiPort()}";

            _stubHttp = HttpMockRepository.At(uri);
            _stubHttp.Stub(x => x.Get(""))
                .Return(homePageResponse)
                .OK();

            var webClient = new WebClientWithTimeout { Timeout = 2 * 1000 };
            string result = webClient.DownloadString(uri);
            Assert.AreEqual(homePageResponse, result);
        }

        public IHttpServer getHttpStub { get { return _stubHttp; } }

        public void SetupPost(string endpoint, string responseBody)
        {
            _stubHttp.Stub(x => x.Post(endpoint))
                .Return(responseBody)
                .OK();
        }

        public void SetupOptions(string endpoint)
        {
            _stubHttp.Stub(x => x.CustomVerb(endpoint, "OPTIONS" ))                
                .OK();
        }
    }
}
