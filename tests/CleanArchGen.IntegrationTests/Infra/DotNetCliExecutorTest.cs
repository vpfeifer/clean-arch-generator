using System;
using System.IO;
using CleanArchGen.Infra.CommandLine;
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
        public void CreateSolutionFile_ShouldExecuteWithSuccess_WhenPathAndNameAreValid()
        {
            _dotnetCli.CreateSolutionFile("testePath", "teste");

            var slnExists = File.Exists("testePath/teste.sln");

            slnExists.Should().BeTrue();
        }

        [Fact]
        public void CreateSolutionFile_ShouldExecuteWithSuccess_WhenPathIsInvalid()
        {
            var invalidPath = "   ";

            Action act = () => _dotnetCli.CreateSolutionFile(invalidPath, "teste");
            
            act.Should().Throw<CouldNotCreateSolutionFileException>();
        }

        [Fact]
        public void CreateSolutionFile_ShouldExecuteWithSuccess_WhenNameIsInvalid()
        {
            var invalidName = "   ";

            Action act = () => _dotnetCli.CreateSolutionFile("testePath", invalidName);
            
            act.Should().Throw<CouldNotCreateSolutionFileException>();
        }
    }
}