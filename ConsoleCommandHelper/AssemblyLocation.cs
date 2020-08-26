using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ConsoleCommandHelper
{
    internal static class AssemblyLocation
    {
        public static string Get(string fileName)
        {
            var executablePaths = GetAssemblyLocations();
            var executablePath = String.Empty;
            var missingPaths = new List<string>();

            while ((executablePaths.Count > 0) && String.IsNullOrEmpty(executablePath))
            {
                executablePath = executablePaths.Dequeue();

                if (FolderContainsFile(executablePath, fileName))
                {
                    executablePath = Path.Combine(executablePath, fileName); ;
                }
                else
                {
                    missingPaths.Add(executablePath);
                    executablePath = String.Empty;
                }
            }

            if (String.IsNullOrEmpty(executablePath))
            {
                throw new FileNotFoundException($"File {fileName} is missing in possible execution locations {String.Join(',', missingPaths.ToArray())}!");
            }

            return executablePath;
        }

        private static List<string> GetFiles(string path)
        {
            return Directory.GetFiles(path).Select(f => Path.GetFileName(f).ToUpperInvariant()).ToList();
        }

        private static bool FolderContainsFile(string path, string fileName)
        {
            return GetFiles(path).Contains(fileName.ToUpperInvariant());
        }

        private static Queue<string> GetAssemblyLocations()
        {
            var executablePaths = new Queue<string>();
            executablePaths.Enqueue(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            executablePaths.Enqueue(AppDomain.CurrentDomain.BaseDirectory);

            return executablePaths;
        }
    }
}