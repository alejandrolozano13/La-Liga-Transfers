using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Club
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
        public string shield { get; set; }
        public string Token { get; set; }
        public List<Player> Players { get; set; }
    }
}