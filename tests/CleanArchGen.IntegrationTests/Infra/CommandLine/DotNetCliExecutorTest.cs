using System;
using System.IO;
using CleanArchGen.Infra.CommandLine;
using FluentAssertions;
using Xunit;

namespace CleanArchGen.IntegrationTests.Infra.CommandLine
{
    public class DotNetCliExecutorTest
    {
        private readonly DotNetCliExecutor _dotnetCli;

        public DotNetCliExecutorTest()
        {
            var commandBuilder = new DotNetCommandBuilder();
            _dotnetCli = new DotNetCliExecutor(commandBuilder);
        }

        [Fact]
        public void CreateSolutionFile_ShouldExecuteWithSuccess_WhenNameIsValid()
        {
            _dotnetCli.CreateSolutionFile("testPath","test");

            var slnExists = File.Exists("testPath/test.sln");

            slnExists.Should().BeTrue();
        }

        [Fact]
        public void CreateSolutionFile_ShouldThrowException_WhenPathIsInvalid()
        {
            var invalidPath = "   ";

            Action act = () => _dotnetCli.CreateSolutionFile(invalidPath, "validName");
            
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CreateSolutionFile_ShouldThrowException_WhenNameIsInvalid()
        {
            var invalidName = "   ";

            Action act = () => _dotnetCli.CreateSolutionFile("validPath", invalidName);
            
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CreateClassLibProject_ShouldExecuteWithSuccess_WhenNameIsValid()
        {
            _dotnetCli.CreateClassLibProject("path", "fooproject");

            var projectWasCreated = File.Exists("path/fooproject.csproj");

            projectWasCreated.Should().BeTrue();
        }

        [Fact]
        public void CreateClassLibProject_ShouldCreateProjectWithPathName_WhenNameIsEmpty()
        {
            var emptyName = string.Empty;

            Action act = () => _dotnetCli.CreateClassLibProject("validPath", emptyName);
            
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CreateClassLibProject_ShouldThrowException_WhenPathIsInvalid()
        {
            var invalidPath = "   ";

            Action act = () => _dotnetCli.CreateClassLibProject(invalidPath, "validName");
            
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CreateWebApiProject_ShouldExecuteWithSuccess_WhenNameIsValid()
        {
            _dotnetCli.CreateWebApiProject("path", "fooproject");

            var projectWasCreated = File.Exists("path/fooproject.csproj");

            projectWasCreated.Should().BeTrue();
        }

        [Fact]
        public void CreateWebApiProject_ShouldCreateProjectWithPathName_WhenNameIsEmpty()
        {
            var emptyName = string.Empty;

            Action act = () => _dotnetCli.CreateWebApiProject("validPath", emptyName);
            
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CreateWebApiProject_ShouldThrowException_WhenPathIsInvalid()
        {
            var invalidPath = "   ";

            Action act = () => _dotnetCli.CreateWebApiProject(invalidPath, "validName");
            
            act.Should().Throw<ArgumentException>();
        }
    }
}