
using MartianRobots.Domain.Services.Contracts;
using MartianRobots.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Repository.Contracts;
using MartianRobots.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MartianRobots.Infrastructure.Configurations
{
    /// <summary>
    /// AutoMapperConfig class.
    /// </summary>
    public static class MongoDBConfig
    {
        /// <summary>
        /// AddMongoDBConfiguration method.
        /// </summary>
        /// <param name="services"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddMongoDBConfiguration(this IServiceCollection services, IConfigurationSection mongoDBDatabaseSettingsConfigurationSection, string connectionStringValue)
        {
            if (services == null) 
                throw new ArgumentNullException(nameof(services));

            services.Configure<MongoDBDatabaseSettings>(mongoDBDatabaseSettingsConfigurationSection);
            services.AddSingleton<IMongoDBDatabaseSettings>(sp => sp.GetRequiredService<IOptions<MongoDBDatabaseSettings>>().Value);
            services.AddSingleton<IMongoClient>(s => new MongoClient(connectionStringValue));            
        }
    }
}