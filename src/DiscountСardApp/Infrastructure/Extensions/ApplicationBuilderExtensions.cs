using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace DiscountСardApp.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(options =>
            {

                // build a swagger endpoint for each discovered API version
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    var apiName = $"{Constants.ApiName} {description.GroupName.ToUpperInvariant()}";
                    options.SwaggerEndpoint($"{description.GroupName}/swagger.json", apiName);
                }

                options.DocumentTitle = $"{Constants.ApiName} - Swagger UI";

                options.DocExpansion(DocExpansion.None);
            });

            return app;
        }

        public static IApplicationBuilder ConfigureSerilog(this IApplicationBuilder app)
        {
            //app.UseSerilogRequestLogging(options =>
            //{
            //    options.EnrichDiagnosticContext = LogHelper.EnrichFromRequest;
            //    options.GetLevel = LogHelper.ExcludeHealthChecks; // Use the custom level to filter the Health Checks from logs (information messages)
            //});

            return app;
        }

        public static IApplicationBuilder ConfigureForwarderOptions(this IApplicationBuilder app)
        {
            var forwardedHeadersOptions = new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            };
            forwardedHeadersOptions.KnownProxies.Clear();
            forwardedHeadersOptions.KnownNetworks.Clear();
            app.UseForwardedHeaders(forwardedHeadersOptions);

            return app;
        }
    }
}