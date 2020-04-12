using System;
using System.IO;
using CleanArchGen.Domain;
using CleanArchGen.Infra.CommandLine;
using CleanArchGen.Infra.Exceptions;
using FluentAssertions;
using Xunit;

namespace CleanArchGen.IntegrationTests.Domain
{
    public class SolutionTest
    {
        [Fact]
        public void Create_ShouldCreateFolderAndSolutionFile()
        {
            var commandBuilder = new DotNetCommandBuilder();
            var dotnetCli = new DotNetCliExecutor(commandBuilder);

            var solution = new Solution(dotnetCli);

            var projectPath = "test";
            var solutionName = "SolutionName";

            solution.Create(projectPath, solutionName);

            Environment.CurrentDirectory.Should().Contain("test");
            File.Exists($"{solutionName}.sln");
        }

        [Fact]
        public void Create_ShouldThrowException_WhenSolutionNameIsInvalid()
        {
            var commandBuilder = new DotNetCommandBuilder();
            var dotnetCli = new DotNetCliExecutor(commandBuilder);

            var solution = new Solution(dotnetCli);

            var projectPath = "test";
            var solutionName = "   ";

            Assert.Throws<ArgumentException>(
                () => solution.Create(projectPath, solutionName)
            );
        }
    }
}