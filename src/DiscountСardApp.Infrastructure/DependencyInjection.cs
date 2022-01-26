using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Discount—ardApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            RegisterDatabase(services);

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

        private static void RegisterDatabase(IServiceCollection services)
        {
            // configure Mongo DB database with the driver
            services.AddMySQLDatabase();

            //TODO: Register repositories here
            // register repositories to work with the data in database
            //services.AddSingleton<IRepository, Repository>();
        }

        private static void AddMySQLDatabase(this IServiceCollection services)
        {
            //TODO: Register our database here

            // Sample:
            //services
            //    .AddSingleton<IMongoClient, MongoClient>(serviceProvider =>
            //        new MongoClient(serviceProvider.GetRequiredService<IOptions<MongoDbOptions>>().Value.ConnectionString))
            //    .AddSingleton<IMongoDatabase>(serviceProvider => serviceProvider
            //        .GetRequiredService<IMongoClient>()
            //        .GetDatabase(serviceProvider.GetRequiredService<IOptions<MongoDbOptions>>().Value.DatabaseName));
        }

        #endregion
    }
}