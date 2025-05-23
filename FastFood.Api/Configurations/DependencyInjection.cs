using FastFood.Application;
using FastFood.Application.Interfaces.Services;
using FastFood.Application.Services;
using FastFood.Domain.Interfaces.Repositories;
using FastFood.Infrastructure;
using FastFood.Infrastructure.Repositories;

namespace FastFood.Api.Configurations
{
    public static class DependencyInjection
    {
        public static void AddDependencies(IServiceCollection services)
        {

            ApplicationConfiguration.Register(services);
            InfraConfiguration.Register(services);
        }
    }
}
