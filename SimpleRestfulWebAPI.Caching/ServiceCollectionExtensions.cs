using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleRestfulWebAPI.Caching
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCaching(this IServiceCollection services, IConfiguration config)
        {
            //Redis Cache 
            services.AddTransient<ICachingService, CachingService>();

            string password = config["Redis:Password"];
            string endpoint = config["Redis:Endpoint"]!;

            services.AddStackExchangeRedisCache(delegate (RedisCacheOptions options)
            {
                options.Configuration = (string.IsNullOrWhiteSpace(password) ? endpoint : (endpoint + ",password=" + password));
            });


            return services;
        }
    }
}
