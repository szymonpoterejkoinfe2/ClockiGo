namespace ClockiGo.Application.Services.Organization.Common
{
    public record GetAllAvailabilitiesOfOrganizationInMonthOfYearResult
    (
        IReadOnlyList<Domain.Entities.Availability> Availabilities
    );
}
