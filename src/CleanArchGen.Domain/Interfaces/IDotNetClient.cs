namespace CleanArchGen.Domain.Interfaces
{
    public interface IDotNetClient
    {
        void CreateSolutionFile(string path, string fileName);
        void CreateClassLibProject(string path, string projectName);
        void CreateWebApiProject(string path, string projectName);
    }
}