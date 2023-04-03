using Amazon.Runtime.Internal;
using AspNetCoreMongodb;
using AspNetCoreMongoDb.Application.Interfaces;
using AspNetCoreMongoDb.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace AspNetCoreMongoDb.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            return services;
        }
        public static IServiceCollection AddMongo(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection(MongoDbOptions.Name);
            var options = new MongoDbOptions
            {
                ConnectionString = section.GetSection("ConnectionString").Value,
                Database = section.GetSection("Database").Value
            };
            services.AddSingleton<MongoDbOptions>(options);
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
