namespace ClockiGo.Infrastructure.Presistance.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public byte Role { get; set; }

        public Guid? OrganizationId { get; set; }
        public OrganizationEntity? Organization { get; set; }

        public ICollection<AvailabilityEntity> Availabilities { get; set; }

    }
}
