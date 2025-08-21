namespace ClockiGo.Domain.Entities
{
    public class Organization
    {
        public Guid Id { get; set; } 
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public List<User> Users { get; set; }
        public List<Availability> Availabilities { get; set; }
    }
}
