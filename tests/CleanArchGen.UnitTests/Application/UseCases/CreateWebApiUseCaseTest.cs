using System.Collections.Generic;
using CleanArchGen.Application.UseCases;
using CleanArchGen.Domain.DefaultLayers;
using CleanArchGen.Domain.Interfaces;
using Moq;
using Xunit;

namespace CleanArchGen.UnitTests
{
    public class CreateWebApiUseCaseTest
    {
        [Fact]
        public void Create_ShouldCreateSolutionFile()
        {
            var solutionMock = new Mock<ISolution>();
            solutionMock.Setup(s => s.Create(It.IsAny<string>(), It.IsAny<string>()));

            var webApi = new Mock<IWebApiLayer>().Object;

            var useCase = new CreateWebApiUseCase(new List<IDefaultLayer>(), solutionMock.Object, webApi);

            useCase.Create("path", "projectName");

            solutionMock.Verify(s => s.Create("path", "projectName"), Times.Once);
        }

        [Fact]
        public void Create_ShouldNotCreateDefaultLayer_WhenDefaultLayerListIsEmpty()
        {
            var solution = new Mock<ISolution>().Object;

            var defaultLayerMock = new Mock<IDefaultLayer>();
            defaultLayerMock.Setup(s => s.Create(It.IsAny<string>(), It.IsAny<string>()));

            var webApi = new Mock<IWebApiLayer>().Object;

            var useCase = new CreateWebApiUseCase(new List<IDefaultLayer>(), solution, webApi);

            useCase.Create("path", "projectName");

            defaultLayerMock.Verify(s => s.Create("path", "projectName"), Times.Never);
        }

        [Fact]
        public void Create_ShouldCreateDefaultLayers()
        {
            var solution = new Mock<ISolution>().Object;

            var defaultLayerMock = new Mock<IDefaultLayer>();
            defaultLayerMock.Setup(s => s.Create(It.IsAny<string>(), It.IsAny<string>()));

            var defaultLayers = new List<IDefaultLayer>{ defaultLayerMock.Object };

            var webApi = new Mock<IWebApiLayer>().Object;

            var useCase = new CreateWebApiUseCase(defaultLayers, solution, webApi);

            useCase.Create("path", "projectName");

            defaultLayerMock.Verify(s => s.Create("path", "projectName"), Times.Once);
        }

        [Fact]
        public void Create_ShouldCreateWebApiProject()
        {
            var solution = new Mock<ISolution>().Object;

            var webApiMock = new Mock<IWebApiLayer>();
            webApiMock.Setup(s => s.Create(It.IsAny<string>(), It.IsAny<string>()));

            var useCase = new CreateWebApiUseCase(new List<IDefaultLayer>(), solution, webApiMock.Object);

            useCase.Create("path", "projectName");

            webApiMock.Verify(s => s.Create("path", "projectName"), Times.Once);
        }
    }
}
