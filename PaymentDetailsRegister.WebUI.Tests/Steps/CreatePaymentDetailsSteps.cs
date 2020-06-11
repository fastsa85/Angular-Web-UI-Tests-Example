using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebUI.Tests.Contexts;
using WebUI.Tests.Models;
using WebUI.Tests.Pages;

namespace WebUI.Tests.Steps
{
    [Binding]
    public class CreatePaymentDetailsSteps
    {
        private PaymentDetailsContext paymentDetailsContext;

        private MockServicesContext mockServicesContext;

        private IWebDriver webBrowser;
        
        public CreatePaymentDetailsSteps(WebBrowserContext webBrowserContext, PaymentDetailsContext paymentDetailsContext, MockServicesContext mockServicesContext)
        {
            this.webBrowser = webBrowserContext.NgWebBrowser;
            this.paymentDetailsContext = paymentDetailsContext;
            this.mockServicesContext = mockServicesContext;
        }

        [When(@"user enters in Create Payment form:")]
        public void WhenUserEntersInCreatePaymentForm(Table table)
        {
            var payment = table.CreateInstance<PaymentDetail>();
            var page = new PaymentDetailRegisterPage(webBrowser);
           
            page.txtCardOwnerName.Click();
            page.txtCardOwnerName.SendKeys(payment.CardOwnerName);

            page.txtCardNumber.SendKeys(payment.CardNumber);

            page.txtExpirationDate.Click();
            page.txtExpirationDate.SendKeys(payment.ExpirationDate);

            page.txtCvv.Click();
            page.txtCvv.SendKeys(payment.CVV);

            paymentDetailsContext.PaymentBeingCreated = payment;
        }
        
        [When(@"user clicks button Submit in Create Payment form")]
        public void WhenUserClicksButtonSubmitInCreatePaymentForm()
        {
            var page = new PaymentDetailRegisterPage(webBrowser);
            page.btnSubmit.Click();
        }
        
        [Then(@"button Submit is enabled in Create Payment form")]
        public void ThenButtonSubmitIsEnabledInCreatePaymentForm()
        {
            string temp = "{\"PaymentId\":0,\"CardOwnerName\":\"John Doe\",\"CardNumber\":\"1234123412341234\",\"ExpirationDate\":\"11 / 44\",\"CVV\":\"123\"}";
            mockServicesContext.PaymentDetailsMock.SetupPost(temp);

            var page = new PaymentDetailRegisterPage(webBrowser);
            Assert.IsTrue(page.btnSubmit.Enabled, "Button 'Submit' is not enabled in CreatePayment form.");
        }

        [Then(@"Payment Details service is called with POST request")]
        public void ThenPaymentDetailsServiceIsCalledWithPOSTRequest()
        {
            var isPostCalled = mockServicesContext.PaymentDetailsMock.IsPostCalled();
            Assert.IsTrue(isPostCalled, "Payment Details service is not called with POST request when expected.");
        }


        [Then(@"the following Payment Detail is asked to be created:")]
        public void ThenTheFollowingPaymentDetailIsAskedToBeCreated(Table table)
        {
            var expectedPaymentBeingCreated = table.CreateInstance<PaymentDetail>();
            var actualPaymentOnMockService = mockServicesContext.PaymentDetailsMock.GetLastPaymentPosted();
            Assert.AreEqual(expectedPaymentBeingCreated, actualPaymentOnMockService, 
                $"The following Payment Detail is not asked to be created at Payment Details service: /n" +
                $"Card Owner Name: {expectedPaymentBeingCreated.CardOwnerName}/n" +
                $"Card Number: {expectedPaymentBeingCreated.CardNumber}/n" +
                $"Expiration Date: {expectedPaymentBeingCreated.ExpirationDate}/n" +
                $"CVV: {expectedPaymentBeingCreated.CVV}/n" +
                $"The last Payment Detail received by Payment Detail service is:" +
                $"Card Owner Name: {actualPaymentOnMockService.CardOwnerName}/n" +
                $"Card Number: {actualPaymentOnMockService.CardNumber}/n" +
                $"Expiration Date: {actualPaymentOnMockService.ExpirationDate}/n" +
                $"CVV: {actualPaymentOnMockService.CVV}/n");
        }

    }
}
