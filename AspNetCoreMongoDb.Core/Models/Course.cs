using AspNetCoreMongoDb.Application.Interfaces;
using MongoDB.Bson.Serialization.Attributes;

namespace AspNetCoreMongodb.Core.Models
{
    public class Course: IIdentifiable<string>
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
    }
}
