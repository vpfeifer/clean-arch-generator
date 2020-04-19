using CleanArchGen.Application.Interfaces;
using CleanArchGen.Application.UseCases;
using CleanArchGen.Domain;
using CleanArchGen.Domain.DefaultLayers;
using CleanArchGen.Domain.Interfaces;
using CleanArchGen.Infra.CommandLine;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchGen.ConsoleApp
{
    public static class Bootstrapper
    {
        public static ServiceProvider ResolveAppDependencies()
        {
            var services = new ServiceCollection();

            services.ResolveDomainDependencies()
                    .ResolveUseCaseDependencies()
                    .ResolveInfraDependencies();

            return services.BuildServiceProvider();
        }

        private static IServiceCollection ResolveDomainDependencies(this IServiceCollection services)
        {
            return services.AddScoped<ISolution, Solution>()
                           .AddScoped<IDefaultLayer, DomainLayer>()
                           .AddScoped<IDefaultLayer, ApplicationLayer>()
                           .AddScoped<IDefaultLayer, InfraLayer>();
        }

        private static IServiceCollection ResolveUseCaseDependencies(this IServiceCollection services)
        {
            return services.AddScoped<ICreateWebApiUseCase, CreateWebApiUseCase>();
        }

        private static IServiceCollection ResolveInfraDependencies(this IServiceCollection services)
        {
            return services.AddScoped<IDotNetClient, DotNetCliExecutor>();
        }
    }
}
