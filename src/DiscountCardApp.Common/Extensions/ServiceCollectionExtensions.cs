using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Discount—ardApp.Common.Extensions
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