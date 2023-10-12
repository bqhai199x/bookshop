using Infrastructure.Common;
using Infrastructure.Common.Interfaces;
using WebApi.Auth;
using WebApi.Services;
using WebApi.Services.Interfaces;

namespace WebApi.Base
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program));
            services.AddJWTAuthorization();
            services.AddAuthorizationSwagger();

            services.AddScoped<IDbFactory, DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddInjectServices(this IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
        }
    }
}
