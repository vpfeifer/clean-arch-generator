using CleanArchGen.Domain.Interfaces;

namespace CleanArchGen.Domain.DefaultLayers
{
    public sealed class DomainLayer : DefaultLayer
    {
        public DomainLayer(IDotNetClient dotNetClient) : base(dotNetClient){}

        protected override string GetLayerName() => "Domain";
    }
}