namespace ConsoleCommandHelper
{
    [Command(Names = new string[] { "ABOUT", "-ABOUT", "--ABOUT" }, FileName = "About.txt")]
    internal class CommandAbout : CommonCommand
    {
    }
}
