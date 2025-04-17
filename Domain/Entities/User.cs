using Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

        public string? ClubId { get; set; }
        public Club? Club { get; set; }
    }
}