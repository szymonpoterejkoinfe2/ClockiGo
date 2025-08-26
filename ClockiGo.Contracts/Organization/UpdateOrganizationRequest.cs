namespace ClockiGo.Contracts.Organization
{
    public record UpdateOrganizationRequest
        (
            Guid OrganizationId,
            string Name,
            string Email,
            string Phone
        );
}
