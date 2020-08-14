using System;

namespace ConsoleCommandHelper
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CommandAttribute : Attribute
    {
        public string[] Names;

        public string FileName;
    }
}
