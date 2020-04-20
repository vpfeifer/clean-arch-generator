using System.Collections.Generic;
using CleanArchGen.Application.Interfaces;
using CleanArchGen.Domain.DefaultLayers;
using CleanArchGen.Domain.Interfaces;

namespace CleanArchGen.Application.UseCases
{
    public class CreateWebApiUseCase : ICreateWebApiUseCase
    {
        private readonly IEnumerable<IDefaultLayer> _defaultLayers;
        private readonly ISolution _solution;
        private readonly IWebApiLayer _webApiLayer;

        public CreateWebApiUseCase(IEnumerable<IDefaultLayer> defaultLayers, ISolution solution, IWebApiLayer webApiLayer)
        {
            _defaultLayers = defaultLayers;
            _solution = solution;
            _webApiLayer = webApiLayer;
        }

        public void Create(string path, string projectName)
        {
            _solution.Create(path, projectName);

            foreach (var layer in _defaultLayers)
            {
                layer.Create(path, projectName);
            }

            _webApiLayer.Create(path, projectName);
        }
    }
}