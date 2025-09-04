using ClockiGo.Domain.Enums;

namespace ClockiGo.Domain.DTOs
{
    public record AvailabilityDTO
        (
                Guid Id,
                int AvailabilityType,
                DateTime AvailableFrom ,
                DateTime AvailableTo ,
                Guid? UserId,
                Guid? OrganizationId
        );
}
