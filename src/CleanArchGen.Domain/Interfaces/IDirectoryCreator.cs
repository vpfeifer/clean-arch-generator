namespace CleanArchGen.Domain.Interfaces
{
    public interface IDirectoryCreator
    {
        void CreateAndSetAsCurrentPath(string path);
    }
}