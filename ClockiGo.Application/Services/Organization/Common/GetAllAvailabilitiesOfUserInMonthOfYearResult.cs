using ClockiGo.Domain.DTOs;

namespace ClockiGo.Application.Services.Organization.Common
{
    public record GetAllAvailabilitiesOfUserInMonthOfYearResult
    (
        IReadOnlyList<AvailabilityDTO> Availabilities
    );
}
