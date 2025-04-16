using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Position
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public string FifaCode { get; set; } // Example: Gk, CB, ST...
    }
}