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

        public async Task AddAsync(TEntity entity)
            => await Collection.InsertOneAsync(entity);

        public async Task DeleteAsync(TIdentifiable id)
            => await Collection.DeleteOneAsync(e => e.Id.Equals(id));
        

        public Task UpdateAsync(TEntity entity)
            => Collection.ReplaceOneAsync(e => e.Id.Equals(entity.Id), entity);

        public async Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
            => await Collection.Find(predicate).ToListAsync();
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
            => await Collection.Find(predicate).SingleOrDefaultAsync();
        public async Task<TEntity> GetAsync(TIdentifiable id)
            => await GetAsync(e => e.Id.Equals(id));
    }
}
