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
            var folderName = "testFolder";

            _dirCreator.CreateAndSetAsCurrentPath(folderName);

            Environment.CurrentDirectory.Should().Contain(folderName);
        }

        [Fact]
        public void Create_ShouldThrowArgumentNullException_WhenPathIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                _dirCreator.CreateAndSetAsCurrentPath(null)
            );
        }
    }
}
