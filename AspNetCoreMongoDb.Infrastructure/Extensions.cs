using AspNetCoreMongodb;
using AspNetCoreMongoDb.Application.Interfaces;
using AspNetCoreMongoDb.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace AspNetCoreMongoDb.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ICourseRepository, CourseRepository>();
            return services;
        }
        public static IServiceCollection AddMongo(this IServiceCollection services, Action<MongoDbOptions> mongoDbOptionsAction)
        {
            var mongoDbOptions = new MongoDbOptions();
            mongoDbOptionsAction(mongoDbOptions);

            services.AddSingleton<MongoDbOptions>(mongoDbOptions);
            services.AddSingleton<IMongoClient>(sp =>
            {
                var options = sp.GetRequiredService<MongoDbOptions>();
                return new MongoClient(options.ConnectionString);
            });
            services.AddTransient<IMongoDatabase>(sp =>
            {
                var options = sp.GetRequiredService<MongoDbOptions>();
                var mongoClient = sp.GetRequiredService<IMongoClient>();
                var mongoDatabase = mongoClient.GetDatabase(options.Database);
                return mongoDatabase;
            });
            return services;
        }
        public static IServiceCollection AddMongoRepository<TEntity, TIdentifiable>(this IServiceCollection services, string collectionName)
            where TEntity : IIdentifiable<TIdentifiable>
        {
            services.AddTransient<IMongoDbRepository<TEntity, TIdentifiable>>(sp =>
            {
                var database = sp.GetRequiredService<IMongoDatabase>();
                return new MongoDbRepository<TEntity,TIdentifiable>(database, collectionName);
            });
            return services;
        }
    }
}
