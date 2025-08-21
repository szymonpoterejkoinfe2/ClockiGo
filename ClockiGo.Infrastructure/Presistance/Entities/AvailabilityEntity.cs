namespace ClockiGo.Infrastructure.Presistance.Entities
{
    public class AvailabilityEntity
    {
        public Guid Id { get; set; }
        public byte AvailabilityType { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }

        // Keys
        public Guid? OrganizationId { get; set; }
        public OrganizationEntity? Organization { get; set; }

        public Guid? UserId { get; set; }
        public UserEntity? User { get; set; }

    }
}
