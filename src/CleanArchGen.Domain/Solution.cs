using CleanArchGen.Domain.Interfaces;

namespace CleanArchGen.Domain
{
    public class Solution : ISolution
    {
        private readonly IDotNetClient _dotnet;

        public Solution(IDotNetClient dotnet)
        {
            _dotnet = dotnet;
        }

        public void Create(string projectPath, string solutionFileName)
        {
            _dotnet.CreateSolutionFile(projectPath, solutionFileName);
        }
    }
}