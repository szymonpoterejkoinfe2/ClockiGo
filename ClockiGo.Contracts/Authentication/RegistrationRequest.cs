namespace ClockiGo.Contracts.Authentication
{
    public record RegistrationRequest
    (
        string FirstName,
        string LastName,
        string Email,
        string Phone,
        string Password
    );
    
}
