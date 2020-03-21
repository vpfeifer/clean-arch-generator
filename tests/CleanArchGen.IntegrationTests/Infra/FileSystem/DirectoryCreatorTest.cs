using System;
using System.IO;
using CleanArchGen.Infra.FileSystem;
using FluentAssertions;
using Xunit;

namespace CleanArchGen.IntegrationTests.Infra.FileSystem
{
    public class DirectoryCreatorTest
    {
        private readonly DirectoryCreator _dirCreator;

        public DirectoryCreatorTest()
        {
            _dirCreator = new DirectoryCreator();
        }

        [Fact]
        public void Create_ShouldCreateFolder_WhenPathIsValid()
        {
            _dirCreator.Create("testFolder");

            var dirInfo =  new DirectoryInfo("testFolder");

            dirInfo.Exists.Should().BeTrue();
        }

        [Fact]
        public void Create_ShouldThrowException_WhenPathIsInvalid()
        {
            Assert.Throws<ArgumentNullException>(() =>
                _dirCreator.Create(null)
            );
        }

        [Fact]
        public void Create_ShouldNotThrowException_WhenDirectoryAlreadyExists()
        {
            _dirCreator.Create("testFolder");
            
            _dirCreator.Create("testFolder");

            var dirInfo =  new DirectoryInfo("testFolder");

            dirInfo.Exists.Should().BeTrue();
        }
    }
}
