namespace CleanArchGen.Domain.Interfaces
{
    public interface IDotNetClient
    {
        void CreateSolutionFile(string path, string name);
    }
}