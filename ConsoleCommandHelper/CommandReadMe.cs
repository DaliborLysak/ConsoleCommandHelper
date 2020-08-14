namespace ConsoleCommandHelper
{
    [Command(Names = new string[] { "README", "-README", "--README" }, FileName = "ReadMe.txt")]
    internal class CommandReadMe : CommonCommand
    {
    }
}
