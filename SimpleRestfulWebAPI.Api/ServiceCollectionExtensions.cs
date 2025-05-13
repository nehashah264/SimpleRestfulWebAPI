using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleRestfulWebAPI.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient<IRestfulApi, RestfulApi>(client =>
            {
                var uri = config["RestfulApi:Url"];

                if (uri == null)
                {
                    throw new ArgumentException("URL for Restful Api is null!");
                }

                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            });
            return services;
        }
    }
}
