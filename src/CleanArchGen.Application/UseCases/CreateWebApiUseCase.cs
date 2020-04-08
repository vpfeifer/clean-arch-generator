using System;
using System.Collections.Generic;
using System.IO;
using CleanArchGen.Domain.DefaultLayers;
using CleanArchGen.Domain.Interfaces;

namespace CleanArchGen.Application.UseCases
{
    public class CreateWebApiUseCase
    {
        private IEnumerable<IDefaultLayer> _defaultLayers;

        private readonly ISolution _solution;

        public CreateWebApiUseCase(IEnumerable<IDefaultLayer> defaultLayers, ISolution solution)
        {
            _defaultLayers = defaultLayers;
            _solution = solution;
        }

        public void Create(string path, string name)
        {
            _solution.Create(path, name);
            
            // Create src folder

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