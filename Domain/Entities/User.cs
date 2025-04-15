using Domain.Enums;

namespace Domain.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

        public string? ClubId { get; set; }
        public Club? Club { get; set; }
    }
}