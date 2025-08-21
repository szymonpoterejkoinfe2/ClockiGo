namespace ClockiGo.Domain.DTOs
{
    public class OrganizationDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public List<UserDTO> Users { get; set; } = new();

    }
}
