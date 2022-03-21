using System.Reflection;
using DiscountCardApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DiscountCardApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            RegisterDatabase(services, configuration);

            RegisterApiClients(services);

            return services;
        }

        #region External services configuration (API clients).

        private static void RegisterApiClients(IServiceCollection services)
        {
            //TODO: Register external apis here

            // client to send the messages
            //services.AddHttpClient<IClient, Client>("Client", (serviceProvider, client) =>
            //        {
            //            client.BaseAddress = new Uri(serviceProvider.GetRequiredService<IOptions<SomeOptions>>().Value.Url);
            //        });
        }

        #endregion

        #region Database configuration.

        private static void RegisterDatabase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMySQLDatabase(configuration);

            //TODO: Register repositories here
            // register repositories to work with the data in database
            //services.AddSingleton<IRepository, Repository>();
        }

        private static void AddMySQLDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("MySQLConnection") ?? configuration.GetConnectionString("MySQLConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    connectionString,
                    new MySqlServerVersion(new Version(8, 0, 28))));

        }

        #endregion
    }
}