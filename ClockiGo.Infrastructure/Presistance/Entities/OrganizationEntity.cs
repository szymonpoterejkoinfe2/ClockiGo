namespace ClockiGo.Infrastructure.Presistance.Entities
{
    public class OrganizationEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public ICollection<UserEntity> Users { get; set; }
    }
}
