using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleCommandHelper
{
    public static class CommandService
    {
        private static readonly Dictionary<string, Func<IConsoleCommand>> Catalog = new Dictionary<string, Func<IConsoleCommand>>();

        static CommandService()
        {
            Add<CommandAbout>();
            Add<CommandHelp>();
            Add<CommandTest>();
            Add<CommandReadMe>();
        }

        public static Action TestMethod { get; set; }

        public static string Execute(string command)
        {
            var commandObject = GetCommand(command?.ToUpperInvariant() ?? String.Empty);

            try
            {
                commandObject?.Execute();
            }
            catch (Exception e)
            {
                Trace.TraceInformation($"Command execution failed with exception: {e}");
            }

            return commandObject != null ? String.Empty : command;
        }

        private static IConsoleCommand GetCommand(string name)
        {
            return Catalog.ContainsKey(name) ? Catalog[name]?.Invoke() : null;
        }

        private static void Add<T>() where T : IConsoleCommand, new()
        {
            GetNames(typeof(T))?.ToList().ForEach(n => Catalog.Add(n, () => { return new T(); }));
        }

        private static string[] GetNames(Type type)
        {
            string[] names = null;
            var memberType = typeof(CommandAttribute);

            if (Attribute.IsDefined(type, memberType))
            {
                if (Attribute.GetCustomAttribute(type, memberType) is CommandAttribute attributeName)
                {
                    names = attributeName?.Names ?? null;
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

            return names;
        }
    }
}
