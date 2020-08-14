namespace ConsoleCommandHelper
{
    [Command(Names = new string[] { "HELP", "-HELP", "--HELP", "?", "-?", "--?" }, FileName = "Help.txt")]
    internal class CommandHelp : CommonCommand
    {
    }
}
