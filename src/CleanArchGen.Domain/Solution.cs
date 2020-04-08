using CleanArchGen.Domain.Interfaces;

namespace CleanArchGen.Domain
{
    public class Solution : ISolution
    {
        private readonly IDotNetClient _dotnet;

        private readonly IDirectoryCreator _dirCreator;

        public Solution(IDirectoryCreator dirCreator, IDotNetClient dotnet)
        {
            _dirCreator = dirCreator;
            _dotnet = dotnet;
        }

        public void Create(string projectPath, string solutionFileName)
        {
            _dirCreator.CreateAndSetAsCurrentPath(projectPath);
            
            _dotnet.CreateSolutionFile(projectPath, solutionFileName);
        }
    }
}