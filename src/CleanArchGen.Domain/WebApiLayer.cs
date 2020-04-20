using CleanArchGen.Domain.Interfaces;

namespace CleanArchGen.Domain
{
    public class WebApiLayer : IWebApiLayer
    {
        private readonly IDotNetClient _dotnet;
        
        public WebApiLayer(IDotNetClient dotnet)
        {
            _dotnet = dotnet;
        }

        public void Create(string path, string projectName)
        {
            _dotnet.CreateWebApiProject($"{path}/src", $"{projectName}.WebApi");
        }
    }
}