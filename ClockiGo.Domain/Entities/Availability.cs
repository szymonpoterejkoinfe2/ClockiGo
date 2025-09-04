using ClockiGo.Domain.Enums;

namespace ClockiGo.Domain.Entities
{
    public class Availability
    {
        public Guid Id { get; set; } = Guid.Empty;
        public AvailabilityType AvailabilityType { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }

        public Guid? UserId { get; set; } = Guid.Empty;
        public Guid? OrganizationId {  get; set; } = Guid.Empty;

    }
}
