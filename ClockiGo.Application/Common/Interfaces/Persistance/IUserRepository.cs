using ClockiGo.Domain.Entities;

namespace ClockiGo.Application.Common.Interfaces.Persistance
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(Guid userID);
        Task<User?> GetUserByEmailAsync(string email);
        Task AddAsync(User user);
        Task<bool> UpdateUserAsync(Domain.Entities.User updatedUser);
        Task<bool> DeleteUserAsync(Guid userID);
    }
}
