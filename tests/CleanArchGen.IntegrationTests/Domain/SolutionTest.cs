using System;
using System.IO;
using CleanArchGen.Domain;
using CleanArchGen.Infra.CommandLine;
using CleanArchGen.Infra.FileSystem;
using FluentAssertions;
using Xunit;

namespace CleanArchGen.IntegrationTests.Domain
{
    public class SolutionTest
    {
        [Fact]
        public void Create_ShouldCreateFolderAndSolutionFile()
        {
            var dirCreator = new DirectoryCreator();
            var dotnetCli = new DotNetCliExecutor();

            var solution = new Solution(dirCreator, dotnetCli);

            var projectPath = "test";
            var solutionName = "SolutionName";

            solution.Create(projectPath, solutionName);

            Environment.CurrentDirectory.Should().Contain("test");
            File.Exists($"{solutionName}.sln");
        }
    }
}