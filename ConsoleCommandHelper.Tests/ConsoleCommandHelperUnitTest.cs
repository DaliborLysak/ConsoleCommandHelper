using Xunit;
using ConsoleCommandHelper;
using System;

namespace ConsoleCommandHelper.UnitTests
{
    public class ConsoleCommandHelperUnitTest
    {
        [Fact]
        public void UnknownCommandOutputTest()
        {
            Assert.Equal("UnknownCommand", CommandService.Execute("UnknownCommand"));
        }

        [Fact]
        public void KnownCommandOutputTest()
        {
            Assert.Equal(String.Empty, CommandService.Execute("--HELP"));
        }
    }
}