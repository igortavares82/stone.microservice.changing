using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stone.Framework.Data.Options;

namespace Stone.Charging.WebApi.Configurations
{
    public static class ConfigureServices
    {
        public static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FirebaseClientOptions>(options =>
            {
                configuration.GetSection("FirebaseClientOptions").Bind(options);
                options.CallTokenFactory();
            });
        }
    }
}