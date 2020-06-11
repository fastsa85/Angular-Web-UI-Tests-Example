using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Tests.Pages
{
    public class PaymentDetailRegisterPage
    {
        public PaymentDetailRegisterPage(ISearchContext searchContext)
        {
            PageFactory.InitElements(searchContext, this);
        }

        /// <summary>
        /// Gets text input 'Card Owner Name' web element.
        /// </summary>
        [FindsBy(How = How.Name, Using = "CardOwnerName")]
        public IWebElement txtCardOwnerName;

        /// <summary>
        /// Gets text input 'Card Number' web element.
        /// </summary>
        [FindsBy(How = How.Name, Using = "CardNumber")]
        public IWebElement txtCardNumber;

        /// <summary>
        /// Gets text input 'Expiration Date' web element.
        /// </summary>
        [FindsBy(How = How.Name, Using = "ExpirationDate")]
        public IWebElement txtExpirationDate;

        /// <summary>
        /// Gets text input 'CVV' web element.
        /// </summary>
        [FindsBy(How = How.Name, Using = "CVV")]
        public IWebElement txtCvv;

        /// <summary>
        /// Gets button 'Submit' web element.
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement btnSubmit;
    }
}
