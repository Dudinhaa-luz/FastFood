using FastFood.Application.Interfaces.Services;
using FastFood.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FastFood.Application
{
    public static class ApplicationConfiguration
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
