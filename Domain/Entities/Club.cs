using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Club
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [Required(ErrorMessage = "O nome do clube é obrigatório.")]
        public string Name { get; set; }

        public string Acronym { get; set; }

        [Required(ErrorMessage = "O escudo do clube é obrigatório.")]
        public string Shield { get; set; }

        public List<string> Players { get; set; } = [];
    }
}