using Domain.Enums;

namespace Domain.Entities
{
    public class Transfer
    {
        public string Id { get; set; }
        
        public string PlayerId { get; set; }
        public Player Player { get; set; }

        public string OriginClubId { get; set; }
        public Club OriginClub { get; set; }

        public string NewClubId { get; set; }
        public Club NewClub { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public StatusTransfers Status { get; set; } = StatusTransfers.Pending;
        public decimal Value { get; set; }
    }
}