using CleanArchGen.Domain.DefaultLayers;
using CleanArchGen.Domain.Interfaces;
using Moq;
using Xunit;

namespace CleanArchGen.UnitTests.Domain.DefaultLayers
{
    public class InfraLayerTest
    {
        [Fact]
        public void Create_ShouldCreateProjectWithCorrectNameInSrcFolder()
        {
            var dotnetCliMock = new Mock<IDotNetClient>();

            var domainLayer = new InfraLayer(dotnetCliMock.Object);

            var testFolder = "test";
            var projectName = "FooProject";

            var expectedFolder = $"{testFolder}/src";
            var expectedName = $"{projectName}.Application";

            domainLayer.Create(testFolder, projectName);

            dotnetCliMock.Verify(x => x.CreateClassLibProject(expectedFolder, expectedName), Times.Once);
        }
    }
}
