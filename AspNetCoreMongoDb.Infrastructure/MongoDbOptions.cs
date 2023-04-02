namespace AspNetCoreMongodb
{
    public class MongoDbOptions
    {
        public const string Name = "MongoDbOptions";
        public string ConnectionString { get; set; } = default!;
        public string Database { get; set; } = default!;    
    }
}
