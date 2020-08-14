using Xunit;
using ConsoleCommandHelper;

namespace ConsoleCommandHelper.UnitTests
{
    public class ConsoleCommandHelperUnitTest
    {
        [Fact]
        public void UnknownCommandTest()
        {
            Assert.Equal("UnknownCommand", CommandService.Execute("UnknownCommand"));
        }
    }
}