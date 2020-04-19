using CleanArchGen.Domain.Interfaces;

namespace CleanArchGen.Domain.DefaultLayers
{
    public class InfraLayer : DefaultLayer
    {
        public InfraLayer(IDotNetClient dotnet) : base(dotnet) { }

        protected override string GetLayerName() => "Infra";
    }
}
