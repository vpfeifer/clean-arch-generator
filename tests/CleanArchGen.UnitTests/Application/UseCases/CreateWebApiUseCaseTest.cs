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
        public void Execute_ShouldCreateSrcFolder()
        {
            var defaultLayers = new Mock<IEnumerable<IDefaultLayer>>();
            var solution = new Mock<ISolution>();
            var directoryCreator = new Mock<IDirectoryCreator>();

            var useCase = new CreateWebApiUseCase(defaultLayers.Object, solution.Object, directoryCreator.Object);

            useCase.Create("test", "TestProject");

            directoryCreator.Verify(x => x.CreateAndSetAsCurrentPath("src"), Times.Once);
        }

        [Fact]
        public void Execute_ShouldCreateWebApiProject()
        {

        }
    }
}
