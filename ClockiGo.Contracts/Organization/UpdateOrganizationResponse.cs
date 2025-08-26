namespace ClockiGo.Contracts.Organization
{
    public record UpdateOrganizationResponse
        (
            Guid? OrganizationId,
            string Name,
            string Email,
            string Phone
        );    
    
}
