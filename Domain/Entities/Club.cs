namespace Domain.Entities
{
    public class Club
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
        public string shield { get; set; }
        public List<Player> Players { get; set; }
    }
}