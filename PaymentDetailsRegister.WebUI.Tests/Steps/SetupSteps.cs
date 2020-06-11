using PaymentDetailsRegister.Helpers;
using SpecFlow.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Protractor;
using TechTalk.SpecFlow;
using WebUI.Tests.Contexts;
using WebUI.Tests.Helpers;
using OpenQA.Selenium.Chrome;

namespace WebUI.Tests.Steps
{
    [Binding]
    public class SetupSteps
    {
        static string webUiAppFolder = $"{SolutionHelper.SolutionFolderPath}\\{ConfigurationHelper.WebUIFolderName()}";
        static string webUiAppHost = ConfigurationHelper.WebUIAppHost();
        static string webUiAppPort = ConfigurationHelper.WebUIAppPort();
        
        static NgAppHelper ngHelper = new NgAppHelper(webUiAppFolder, webUiAppHost, webUiAppPort);

        private WebBrowserContext webBrowserContext;

        public SetupSteps(WebBrowserContext webBrowserContext)
        {
            this.webBrowserContext = webBrowserContext;
        }

        /// <summary>
        /// One time setup to complete before the test run.
        /// </summary>
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ngHelper.StartNgApp();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ngHelper.StopNgApp();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--no-sandbox");
            var webDriver = new ChromeDriver(options);
            //webDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
            //webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            webBrowserContext.WebDriver = webDriver;

            var webBrowser = new NgWebDriver(webDriver);            
            webBrowserContext.NgWebBrowser = new NgWebDriver(webDriver);

            webBrowserContext.NgWebBrowser.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
            webBrowserContext.NgWebBrowser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

            webBrowserContext.NgWebBrowser.IgnoreSynchronization = true;
            webBrowserContext.NgWebBrowser.Navigate().GoToUrl(ngHelper.FullUrl);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            webBrowserContext.NgWebBrowser.Close();            
        }
    }
}
