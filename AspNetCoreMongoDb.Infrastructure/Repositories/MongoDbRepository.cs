using AspNetCoreMongoDb.Application.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreMongoDb.Infrastructure
{
    internal class MongoDbRepository<TEntity, TIdentifiable> : IMongoDbRepository<TEntity, TIdentifiable> where TEntity : IIdentifiable<TIdentifiable>
    {
        public MongoDbRepository(IMongoDatabase database, string collectionName) 
        {
            Collection = database.GetCollection<TEntity>(collectionName);
        }
        public IMongoCollection<TEntity> Collection { get; } = default!;

        public Task AddAsync(TEntity entity)
            => Collection.InsertOneAsync(entity);

        public Task DeleteAsync(TIdentifiable id)
            => Collection.DeleteOneAsync(e => e.Id.Equals(id));

        public Task UpdateAsync(TEntity entity)
            => Collection.ReplaceOneAsync(e => e.Id.Equals(entity.Id), entity);

        public async Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        => await Collection.Find(predicate).ToListAsync();
    }
}
