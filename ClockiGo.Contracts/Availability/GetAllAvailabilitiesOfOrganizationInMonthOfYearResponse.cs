using ClockiGo.Domain.DTOs;

namespace ClockiGo.Contracts.Availability
{
    public record GetAllAvailabilitiesOfOrganizationInMonthOfYearResponse
        (
            DateTime MonthOfYear,
            IReadOnlyList<AvailabilityDTO> Availabilities
        );
}
