using FastFood.Application;
using FastFood.Infrastructure;

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
