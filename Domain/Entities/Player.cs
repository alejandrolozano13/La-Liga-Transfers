using Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Player
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Name { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string Nationality { get; set; }
        public string ClubId { get; set; }
        public PlayerPosition Position { get; set; }
        public List<Transfer> Transfers { get; set; } = [];
    }
}