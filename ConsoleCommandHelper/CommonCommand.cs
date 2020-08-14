using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ConsoleCommandHelper
{
    internal class CommonCommand : IConsoleCommand
    {
        public void Execute()
        {
            var executablePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (Directory.Exists(executablePath))
            {
                var fileName = GetFileName(this.GetType());
                var path = Path.Combine(executablePath, fileName);
                if (Directory.GetFiles(executablePath).Select(f => Path.GetFileName(f).ToUpperInvariant()).ToList().Contains(fileName.ToUpperInvariant()))
                {
                    Execute(path);
                }
                else
                {
                    throw new FileNotFoundException($"File {path} is missing!");
                }
            }
        }

        protected virtual void Execute(string path)
        {
            Console.WriteLine(File.ReadAllText(path));
        }

        private static string GetFileName(Type type)
        {
            string fileName = null;
            var memberType = typeof(CommandAttribute);

            if (Attribute.IsDefined(type, memberType))
            {
                if (Attribute.GetCustomAttribute(type, memberType) is CommandAttribute attributeName)
                {
                    fileName = attributeName?.FileName ?? null;
                }
                else
                {
                    Trace.TraceInformation($"The description could not be retrieved for {nameof(type)}.");
                }
            }
            else
            {
                Trace.TraceInformation($"The AssemblyDescription attribute is not defined for assembly {type}.");
            }

            return fileName;
        }
    }
}
