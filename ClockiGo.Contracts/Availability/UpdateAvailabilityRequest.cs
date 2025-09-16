namespace ClockiGo.Contracts.Availability
{
    public record UpdateAvailabilityRequest
    (
        Guid Id,
        int AvailabilityType,
        DateTime AvailableFrom,
        DateTime AvailableTo
    );
}
