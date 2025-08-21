namespace ClockiGo.Contracts.Organization
{
    public record AddOrganizationRequest
        (
          string Name,
          string Email,
          string Phone
        );
}
