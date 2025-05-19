using FastFood.Application.Interfaces.Services;
using FastFood.Application.Services;
using FastFood.Domain.Interfaces.Repositories;
using FastFood.Infrastructure.Repositories;

namespace FastFood.Api.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {

            services.AddServices();
            services.AddRepositores();

            return services;
        }


        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }

        private static IServiceCollection AddRepositores(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));

            return services;
        }
    }
}
