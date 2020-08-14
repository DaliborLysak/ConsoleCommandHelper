using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleCommandHelper
{
    [Command(Names = new string[] { "TEST", "-TEST", "--TEST" }, FileName = "Test.txt")]
    internal class CommandTest : CommonCommand
    {
        private const string SELF_TEST =
@"ABOUT
-ABOUT
--ABOUT
HELP
-HELP
--HELP
TEST
-TEST
--TEST
?
-?
--?
README
-README
--README";

        protected override void Execute(string path)
        {
            //base.Execute(path);

            if (CommandService.TestMethod != null)
            {
                CommandService.TestMethod.Invoke();
            }
            else
            {
                // self test
                var testNames = new List<string>();
                if (Attribute.GetCustomAttribute(this.GetType(), typeof(CommandAttribute)) is CommandAttribute attributeName)
                {
                    testNames = attributeName?.Names?.ToList() ?? new List<string>();
                }

                var commands = SELF_TEST.Split(Environment.NewLine).Select(n => n.ToUpperInvariant()).Where(l => !testNames.Contains(l)).ToList();
                commands.ForEach(c => CommandService.Execute(c));
            }
        }
    }
}
