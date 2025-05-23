using FastFood.Domain.Interfaces.Repositories;
using FastFood.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FastFood.Infrastructure
{
    public static class InfraConfiguration
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
