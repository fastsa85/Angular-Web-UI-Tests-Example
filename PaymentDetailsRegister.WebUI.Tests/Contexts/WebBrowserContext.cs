using Protractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebUI.Tests.Contexts
{
    public class WebBrowserContext
    {
        public NgWebDriver NgWebBrowser { get; set; }
        public IWebDriver WebDriver { get; set; }
    }
}
