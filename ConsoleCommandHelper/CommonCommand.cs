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
            Execute(AssemblyLocation.Get(GetFileName(this.GetType())));
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
