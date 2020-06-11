using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Tests.Helpers
{
    class ConfigurationHelper
    {
        private const string WebUIAppFolderName = "WebUIAppFolderName";
        private const string WebUIAppHostSettingName = "WebUIAppHost";
        private const string WebUIAppPortSettingName = "WebUIAppPort";
        private const string MockPaymentDetailsApiHostSettingName = "MockPaymentDetailsApiHost";
        private const string MockPaymentDetailsApiPortSettingName = "MockPaymentDetailsApiPort";


        /// <summary>
        /// Gets the folder name for the Web UI application.
        /// </summary>
        public static string WebUIFolderName() => ConfigurationManager.AppSettings[WebUIAppFolderName];

        /// <summary>
        /// Gets the host for the Web UI application.
        /// </summary>
        public static string WebUIAppHost() => ConfigurationManager.AppSettings[WebUIAppHostSettingName];

        /// <summary>
        /// Gets the port for the Web UI application.
        /// </summary>
        public static string WebUIAppPort() => ConfigurationManager.AppSettings[WebUIAppPortSettingName];

        /// <summary>
        /// Gets the host for the MOCK Payments Register Details api application.
        /// </summary>
        /// <returns></returns>
        public static string MockPaymentDetailsApiHost() =>
            ConfigurationManager.AppSettings[MockPaymentDetailsApiHostSettingName];

        /// <summary>
        /// Gets the port for the MOCK Payments Register Details api application.
        /// </summary>
        /// <returns></returns>
        public static string MockPaymentDetailsApiPort() =>
            ConfigurationManager.AppSettings[MockPaymentDetailsApiPortSettingName];
    }
}
