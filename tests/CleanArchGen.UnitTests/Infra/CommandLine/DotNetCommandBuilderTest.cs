using System;
using CleanArchGen.Infra.CommandLine;
using CleanArchGen.Infra.Exceptions;
using FluentAssertions;
using Xunit;

namespace CleanArchGen.UnitTests.Infra.CommandLine
{
    public class DotNetCommandBuilderTest
    {
        [Fact]
        public void BuildNewSolution_ShouldReturnCommand()
        {
            var expectedCommand = "new sln";

            var result = new DotNetCommandBuilder()
                .NewSolution()
                .Build();

            result.Should().Be(expectedCommand);
        }

        [Fact]
        public void BuildNewSolution_ShouldThrowException_WhenDefaultCommandAlreadyDefined()
        {
            Assert.Throws<DefaultCommandAlreadyDefinedException>(() =>
            {
                new DotNetCommandBuilder()
                    .NewSolution()
                    .NewSolution();
            });
        }

        [Fact]
        public void BuildNewClassLib_ShouldReturnCommand()
        {
            var expectedCommand = "new classlib";

            var result = new DotNetCommandBuilder()
                .NewClassLib()
                .Build();

            result.Should().Be(expectedCommand);
        }

        [Fact]
        public void BuildNewClassLib_ShouldThrowException_WhenDefaultCommandAlreadyDefined()
        {
            Assert.Throws<DefaultCommandAlreadyDefinedException>(() =>
            {
                new DotNetCommandBuilder()
                    .NewClassLib()
                    .NewClassLib();
            });
        }

        [Fact]
        public void BuildWithPath_ShouldThrowException_WhenDefaultCommandIsNotDefined()
        {
            Assert.Throws<DefaultCommandMustBeDefinedException>(() =>
            {
                new DotNetCommandBuilder()
                    .WithPath("validPath");
            });
        }

        [Fact]
        public void BuildWithPath_ShouldThrowException_WhenPathIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new DotNetCommandBuilder()
                    .WithPath(null);
            });
        }

        [Fact]
        public void BuildWithPath_ShouldThrowException_WhenPathIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new DotNetCommandBuilder()
                    .WithPath(string.Empty);
            });
        }

        [Fact]
        public void BuildWithPath_ShouldThrowException_WhenPathIsWhiteSpaces()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new DotNetCommandBuilder()
                    .WithPath("   ");
            });
        }

        [Fact]
        public void BuildWithName_ShouldThrowException_WhenDefaultCommandIsNotDefined()
        {
            Assert.Throws<DefaultCommandMustBeDefinedException>(() =>
            {
                new DotNetCommandBuilder()
                    .WithName("validName");
            });
        }

        [Fact]
        public void BuildWithName_ShouldThrowException_WhenNameIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new DotNetCommandBuilder()
                    .WithName(null);
            });
        }

        [Fact]
        public void BuildWithName_ShouldThrowException_WhenNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new DotNetCommandBuilder()
                    .WithName(string.Empty);
            });
        }

        [Fact]
        public void BuildWithName_ShouldThrowException_WhenNameIsWhiteSpaces()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new DotNetCommandBuilder()
                    .WithName("   ");
            });
        }

        [Fact]
        public void BuildWithNoRestore_ShouldThrowException_WhenDefaultCommandIsNotDefined()
        {
            Assert.Throws<DefaultCommandMustBeDefinedException>(() =>
            {
                new DotNetCommandBuilder()
                    .WithNoRestore();
            });
        }

        [Fact]
        public void BuildWithForce_ShouldThrowException_WhenDefaultCommandIsNotDefined()
        {
            Assert.Throws<DefaultCommandMustBeDefinedException>(() =>
            {
                new DotNetCommandBuilder()
                    .WithForce();
            });
        }

        [Fact]
        public void BuildNewSolutionWithPath_ShouldReturnCommand()
        {
            var expectedCommand = "new sln -o validPath";

            var result = new DotNetCommandBuilder()
                .NewSolution()
                .WithPath("validPath")
                .Build();

            result.Should().Be(expectedCommand);
        }

        [Fact]
        public void BuildNewSolutionWithName_ShouldReturnCommand()
        {
            var expectedCommand = "new sln -n validName";

            var result = new DotNetCommandBuilder()
                .NewSolution()
                .WithName("validName")
                .Build();

            result.Should().Be(expectedCommand);
        }

        [Fact]
        public void BuildNewSolutionWithForce_ShouldReturnCommand()
        {
            var expectedCommand = "new sln --force";

            var result = new DotNetCommandBuilder()
                .NewSolution()
                .WithForce()
                .Build();

            result.Should().Be(expectedCommand);
        }

        [Fact]
        public void BuildNewClassLibWithNoRestore_ShouldReturnCommand()
        {
            var expectedCommand = "new classlib --no-restore";

            var result = new DotNetCommandBuilder()
                .NewClassLib()
                .WithNoRestore()
                .Build();

            result.Should().Be(expectedCommand);
        }

        [Fact]
        public void BuildNewWebApi_ShouldReturnCommand()
        {
            var expectedCommand = "new webapi";

            var result = new DotNetCommandBuilder()
                .NewWebApi()
                .Build();

            result.Should().Be(expectedCommand);
        }
    }
}