using ClockiGo.Domain.DTOs;

namespace ClockiGo.Contracts.Availability
{
    public record GetAllAvailabilitiesOfUserInMonthOfYearResponse
    (
        DateTime MonthOfYear,
        IReadOnlyList<AvailabilityDTO> Availabilities
        );
    
}
