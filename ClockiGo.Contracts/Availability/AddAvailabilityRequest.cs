namespace ClockiGo.Contracts.Availability
{
    public record AddAvailabilityRequest
        (
            byte AvailabilityType,
            DateTime AvailabilityFrom,
            DateTime AvailabilityTo,
            Guid UserId,
            Guid OrganizationId
        );
}
