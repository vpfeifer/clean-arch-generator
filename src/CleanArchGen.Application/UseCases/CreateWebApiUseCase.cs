using System.Collections.Generic;
using CleanArchGen.Domain.DefaultLayers;
using CleanArchGen.Domain.Interfaces;

namespace CleanArchGen.Application.UseCases
{
    public class CreateWebApiUseCase
    {
        private readonly IEnumerable<IDefaultLayer> _defaultLayers;
        private readonly ISolution _solution;
        private readonly IDirectoryCreator _directoryCreator;

        public CreateWebApiUseCase(IEnumerable<IDefaultLayer> defaultLayers, ISolution solution, IDirectoryCreator directoryCreator)
        {
            _defaultLayers = defaultLayers;
            _solution = solution;
            _directoryCreator = directoryCreator;
        }

        public void Create(string path, string name)
        {
            _solution.Create(path, name);

            _directoryCreator.CreateAndSetAsCurrentPath("src");

            // Create Domain, Application, Infra layers
            // foreach (var layer in _defaultLayers)
            // {
            //     layer.Create(project);
            // }


            // Create Web Api

            // Create tests folder
            // Create UnitTests project
            // Create IntegrationTests project
            // Create FuncionalTests classlib

        }
    }
}