using ClockiGo.Domain.DTOs;

namespace ClockiGo.Contracts.Availability
{
    public record GetAllAvailabilitiesOfUserResponse
        (
            IReadOnlyList<AvailabilityDTO> Availabilities
        );
}
