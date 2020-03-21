using System;
using System.IO;
using System.Threading.Tasks;
using CleanArchGen.Infra;
using CleanArchGen.Infra.Exceptions;
using FluentAssertions;
using Xunit;

namespace CleanArchGen.IntegrationTests.Infra
{
    public class DotNetCliExecutorTest
    {
        private readonly DotNetCliExecutor _dotnetCli;

        public DotNetCliExecutorTest()
        {
            _dotnetCli = new DotNetCliExecutor();
        }

        [Fact]
        public void ExecuteAsync_ShouldExecuteWithSuccess_WhenDotNetCommandIsValid()
        {
            _dotnetCli.Execute("new sln -n teste --force");

            var slnExists = File.Exists("teste.sln");

            slnExists.Should().BeTrue();
        }

        [Fact]
        public void ExecuteAsync_ShouldThrowsException_WhenDotNetCommandIsInvalid()
        {
            var command = "invalidcommand";

            Action act = () => _dotnetCli.Execute(command);
            
            act.Should().Throw<ErrorExecutingDotNetCommandException>()
                .And.Message.Should().Contain(command);
        }
    }
}