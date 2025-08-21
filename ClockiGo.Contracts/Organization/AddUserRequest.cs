namespace ClockiGo.Contracts.Organization
{
    public record AddUserRequest
        (
            Guid OrganizationId,
            Guid UserId
        );
}
