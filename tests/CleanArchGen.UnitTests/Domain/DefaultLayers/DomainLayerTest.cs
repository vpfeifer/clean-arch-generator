using CleanArchGen.Domain.DefaultLayers;
using CleanArchGen.Domain.Interfaces;
using Moq;
using Xunit;

namespace CleanArchGen.UnitTests.Domain.DefaultLayers
{
    public class DomainLayerTest
    {
        [Fact]
        public void Create_ShouldCreateProjectWithCorrectName()
        {
            var dotnetCliMock = new Mock<IDotNetClient>();
            dotnetCliMock.Setup(x => x.CreateClassLibProject(It.IsAny<string>(), It.IsAny<string>()));

            var domainLayer = new DomainLayer(dotnetCliMock.Object);

            var testFolder = "test";
            var projectName = "FooProject";

            var expectedFolder = $"{testFolder}/src";
            var expectedName = $"{projectName}.Domain";

            domainLayer.Create(testFolder, projectName);

            dotnetCliMock.Verify(x => x.CreateClassLibProject(expectedFolder, expectedName), Times.Once);
        }
    }
}