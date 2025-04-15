namespace Applicatiom.DTOs
{
    public class CreateTransferRequest
    {
        public string PlayerId { get; set; }
        public string NewClub { get; set; }
        public decimal Value { get; set; }
    }
}