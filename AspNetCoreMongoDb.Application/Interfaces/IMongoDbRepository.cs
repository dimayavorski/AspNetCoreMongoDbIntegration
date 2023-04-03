using MongoDB.Driver;
using System.Linq.Expressions;

namespace AspNetCoreMongoDb.Application.Interfaces
{
    public interface IMongoDbRepository<TEntity, TIdentifiable> where TEntity : IIdentifiable<TIdentifiable>
    {
        IMongoCollection<TEntity> Collection { get; }
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TIdentifiable id);
        Task<TEntity> GetAsync(TIdentifiable id);
        Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    }
    
}
