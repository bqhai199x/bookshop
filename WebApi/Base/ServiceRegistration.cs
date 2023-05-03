using Infrastructure.Common;
using Infrastructure.Common.Interfaces;
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
    }
}
