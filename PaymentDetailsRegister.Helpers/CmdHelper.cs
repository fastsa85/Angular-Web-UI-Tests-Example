using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PaymentDetailsRegister.Helpers
{
    public class CmdHelper
    {
        public Process CreateCmdProcess(string workingDirectory, string command)
        {
            return new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    WorkingDirectory = workingDirectory,
                    FileName = "cmd.exe",
                    Arguments = $@"/c {command}",
                    CreateNoWindow = true,
                    UseShellExecute = false
                }
            };
        }
    }
}
