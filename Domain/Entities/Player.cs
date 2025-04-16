using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Player
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string Nationality { get; set; }
        public string ClubId { get; set; }
        public Club Club { get; set; }
        public string PositionId { get; set; }
        public Position Position { get; set; }
        public List<Transfer> Transfers { get; set; } = new List<Transfer>();
    }
}