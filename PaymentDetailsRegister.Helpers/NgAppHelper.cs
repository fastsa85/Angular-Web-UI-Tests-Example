using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace PaymentDetailsRegister.Helpers
{
    public class NgAppHelper
    {
        public string Url { get; private set; }
        public string Port { get; private set; }
        public Uri FullUrl { get; private set; }

        private string ApplicationPath { get; }
        private CmdHelper cmdHelper;
        private HttpHelper httpHelper;
        

        public NgAppHelper(string applicationPath, string url, string port="4200")
        {
            ApplicationPath = applicationPath;
            Url = url;
            Port = port;
            FullUrl = new Uri($"{Url}:{Port}");

            cmdHelper = new CmdHelper();
            httpHelper = new HttpHelper();
        }

        public void StartNgApp()
        {
            var command = $"ng serve --port {Port}";
            var cmd = cmdHelper.CreateCmdProcess(ApplicationPath, command);

            cmd.Start();
            httpHelper.WaitForUrlAlive(FullUrl.OriginalString);
        }

        public void StopNgApp()
        {
            var command = $@"for /f ""tokens=5"" %a in ('netstat -ano ^| find ""{Port}"" ^| find ""LISTENING""') do taskkill /f /pid %a";
            var cmd = cmdHelper.CreateCmdProcess(ApplicationPath, command);

            cmd.Start();
            httpHelper.WaitForUrlNotAlive(FullUrl.OriginalString);
        }
    }
}
