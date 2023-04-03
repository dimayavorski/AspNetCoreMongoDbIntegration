using AspNetCoreMongodb.Core.Models;
using AspNetCoreMongoDb.Application.Interfaces;
using MongoDB.Bson.Serialization.Attributes;

namespace AspNetCoreMongodb.Models
{
    public class Student: IIdentifiable<string>
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Major { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public List<string> CourseIds { get; set; } = new List<string>();
        [BsonIgnore]
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
