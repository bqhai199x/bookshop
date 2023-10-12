using WebApi.Auth;
using WebApi.Base;

namespace WebApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            Configuration.Initialization(builder.Configuration);

            builder.Services.AddInfrastructure();
            builder.Services.AddInjectServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(builder => builder
                         .AllowAnyMethod()
                         .AllowAnyHeader()
                         .SetIsOriginAllowed(_ => true));

            app.UseAuthorization();
            app.UseMiddleware<ExceptionHandler>();
            app.UseMiddleware<HttpLogging>();

            app.MapControllers();

            app.Run();
        }
    }
}