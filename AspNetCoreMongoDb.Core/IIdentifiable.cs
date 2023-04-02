namespace AspNetCoreMongoDb.Application.Interfaces
{
    public interface IIdentifiable<T>
    {
        T? Id { get; }
    }
    
}
