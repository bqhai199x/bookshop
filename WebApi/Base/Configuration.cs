using Serilog;
using Serilog.Events;
using WebApi.Auth;

namespace WebApi.Base
{
    public static class Configuration
    {
        public static void Initialization(IConfiguration config)
        {
            ConfigJWT(config);
            CreateLogger();
        }

        private static void ConfigJWT(IConfiguration config)
        {
            JwtConfig.ExpireTime = config.GetValue<int>("Jwt:ExpireTime");
            JwtConfig.SecretKey = config.GetValue<string>("Jwt:Key")!;
        }

        private static void CreateLogger()
        {
            long fileLogSize = 2097152; //2MB
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Error)
                .WriteTo.File(path: "logs/Info/Log_.txt",
                               restrictedToMinimumLevel: LogEventLevel.Information,
                               rollingInterval: RollingInterval.Day,
                               rollOnFileSizeLimit: true,
                               fileSizeLimitBytes: fileLogSize)
                .WriteTo.File(path: "logs/Error/Log_.txt",
                               restrictedToMinimumLevel: LogEventLevel.Error,
                               rollingInterval: RollingInterval.Day,
                               rollOnFileSizeLimit: true,
                               fileSizeLimitBytes: fileLogSize)
                .CreateLogger();
        }
    }
}
