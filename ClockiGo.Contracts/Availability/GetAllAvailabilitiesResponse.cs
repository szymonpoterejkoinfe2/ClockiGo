using ClockiGo.Domain.DTOs;

namespace ClockiGo.Contracts.Availability
{
    public record GetAllAvailabilitiesResponse
        (
            IReadOnlyList<AvailabilityDTO> Availabilities
        );
}
