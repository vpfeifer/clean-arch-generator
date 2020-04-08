namespace CleanArchGen.Domain.DefaultLayers
{
    public interface IDefaultLayer
    {
        string Name { get; }

        void Create();
    }
}