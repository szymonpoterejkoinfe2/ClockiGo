using ClockiGo.Domain.DTOs;

namespace ClockiGo.Contracts.Availability
{
    public record GetAllAvailabilitiesOfOrganizationResponse
        (
            IReadOnlyList<AvailabilityDTO> Availabilities
        );
}
