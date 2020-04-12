using CleanArchGen.Domain.Interfaces;

namespace CleanArchGen.Domain.DefaultLayers
{
    public abstract class DefaultLayer : IDefaultLayer
    {
        private readonly IDotNetClient _dotnet;
        
        public DefaultLayer(IDotNetClient dotnet)
        {
            _dotnet = dotnet;
        }

        protected abstract string GetLayerName();

        public void Create(string path, string projectName)
        {
            _dotnet.CreateClassLibProject($"{path}/src", $"{projectName}.{GetLayerName()}");
        }
    }
}