using ClockiGo.Domain.Enums;

namespace ClockiGo.Domain.Entities
{
    public class User
    {
        public Guid Id {  get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone {  get; set; } = null!;
        public string Password { get; set; } = null!;
        public Role Role { get; set; }

        // Keys
        public Guid? OrganizationId { get; set; }

    }
}
