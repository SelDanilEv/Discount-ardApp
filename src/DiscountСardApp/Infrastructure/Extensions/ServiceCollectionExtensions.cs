using System.Text.Json.Serialization;
using DiscountСardApp.Application;
using DiscountСardApp.Common.Extensions;
using DiscountСardApp.Infrastructure.Configuration;
using DiscountСardApp.Infrastructure.Swagger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DiscountСardApp.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApiService(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment environment,
            bool httpServices = false)
        {
            // add all DI modules
            services.AddExternalServices(configuration);

            if (httpServices)
            {
                services.ConfigureHttpServices(environment, configuration);
            }

            return services;
        }

        private static IServiceCollection AddExternalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConfiguration();
            services.AddApplication();
            services.AddInfrastructure(configuration);

            return services;
        }

        private static IServiceCollection ConfigureHttpServices(this IServiceCollection services,
            IWebHostEnvironment environment, IConfiguration configuration)
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });

            // add API controllers here
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.ConfigureApiVersions();

            // add support for the integration with IHttpContextAccessor
            services.AddHttpContextAccessor();

            // configure Swagger Gen rules to generate API documentation
            services.ConfigureSwaggerGeneration();

            return services;
        }

        private static IServiceCollection ConfigureApiVersions(this IServiceCollection services)
        {
            // add API Version support
            services.AddApiVersioning(options =>
            {
                // reporting API versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            // add API Explorer - to work with API versions
            services.AddVersionedApiExplorer(
                options =>
                {
                    // add the versioned API explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });

            return services;
        }

        private static IServiceCollection ConfigureSwaggerGeneration(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                // enable annotations for detailed descriptions
                options.EnableAnnotations();

                // add a custom operation filter which sets default values
                options.OperationFilter<SwaggerDefaultValues>();

            });

            return services;
        }
   }
}