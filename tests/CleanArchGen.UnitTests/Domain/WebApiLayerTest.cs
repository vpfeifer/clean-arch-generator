using CleanArchGen.Domain;
using CleanArchGen.Domain.Interfaces;
using Moq;
using Xunit;

namespace CleanArchGen.UnitTests.Domain
{
    public class WebApiLayerTest
    {
        [Fact]
        public void Create_ShouldCreateProjectWithCorrectNameInSrcFolder()
        {
            var dotnetCliMock = new Mock<IDotNetClient>();
            dotnetCliMock.Setup(x => x.CreateWebApiProject(It.IsAny<string>(), It.IsAny<string>()));

            var domainLayer = new WebApiLayer(dotnetCliMock.Object);

            var testFolder = "test";
            var projectName = "FooProject";

            var expectedFolder = $"{testFolder}/src";
            var expectedName = $"{projectName}.WebApi";

            domainLayer.Create(testFolder, projectName);

            dotnetCliMock.Verify(x => x.CreateWebApiProject(expectedFolder, expectedName), Times.Once);
        }
    }
}