using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace CRM.CrossCutting.Extensions
{
    public static class MongoExtensions
    {
        public static IServiceCollection AddMongoSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["MongoSettings:ConnectionString"];
            var databaseName = configuration["MongoSettings:Database"];

            var mongoClient = new MongoClient(connectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseName);

            services.AddSingleton(mongoDatabase); 

            return services;
        }
    }
}
