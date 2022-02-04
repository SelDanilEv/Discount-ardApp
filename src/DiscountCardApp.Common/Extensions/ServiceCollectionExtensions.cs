using Microsoft.Extensions.DependencyInjection;

namespace DiscountСardApp.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddConfiguration(this IServiceCollection services)
        {
            //TODO: register options here

            //services.AddApplicationOptions<DbOptions>(nameof(DbOptions));
        }
    }
}