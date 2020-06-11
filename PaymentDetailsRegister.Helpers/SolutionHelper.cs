using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace PaymentDetailsRegister.Helpers
{
    public class SolutionHelper
    {
        /// <summary>
        /// Gets the path of the folder that contains the solution.
        /// </summary>
        public static string SolutionFolderPath
        {
            get
            {
                var assemblyPath = AssemblyLocation();
                var currentFolderPath = Path.GetDirectoryName(assemblyPath);
                var directory = new DirectoryInfo(currentFolderPath);

                while (directory != null && directory.GetFiles("*.sln").Length == 0)
                {
                    directory = directory.Parent;
                }
                return directory?.FullName ?? string.Empty;
            }
        }

        public static string AssemblyLocation()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var codebase = new Uri(assembly.CodeBase);
            return codebase.LocalPath;
        }
    }
}
