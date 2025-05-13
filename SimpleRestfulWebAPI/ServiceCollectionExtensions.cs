using FluentValidation;
using SimpleRestfulWebAPI.Api;
using SimpleRestfulWebAPI.Caching;
using SimpleRestfulWebAPI.Domain.Models;
using SimpleRestfulWebAPI.Middleware;
using SimpleRestfulWebAPI.Services;
using SimpleRestfulWebAPI.Validators;

namespace SimpleRestfulWebAPI
{
    public static class ServiceCollectionExtensions
    {
        // Register All Services
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            // Middleware
            services.AddTransient<ExceptionMiddleware>();

            // Validator
            services.AddScoped<IValidator<ProductAddRequestDto>, ProductRequestDtoValidator>();

            // Caching Service
            services.AddCaching(config);

            // Product Services
            services.AddServices();

            // Restful API
            services.AddApi(config);

            return services;
        }
    }
}
