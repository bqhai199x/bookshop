using Infrastructure.Common.Interfaces;
using Infrastructure.Common;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;
using WebApi.Services;
using WebApi.Services.Interfaces;

namespace WebApi.Base
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IDbFactory, DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddInjectServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
        }

        public static void AddInjectReposistories(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
        }
    }
}
