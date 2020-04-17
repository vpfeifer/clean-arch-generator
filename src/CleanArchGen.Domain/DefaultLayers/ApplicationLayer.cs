using CleanArchGen.Domain.Interfaces;

namespace CleanArchGen.Domain.DefaultLayers
{
    public class ApplicationLayer : DefaultLayer
    {
        public ApplicationLayer(IDotNetClient dotnet) : base(dotnet) {}

        protected override string GetLayerName() => "Application";
    }
}