using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Infrastructure.Presistance.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ClockiGo.Infrastructure.Presistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ClockiGoContext _clockiGoContext;
        private readonly IMapper _mapper;

        public UserRepository(ClockiGoContext clockiGoContext, IMapper mapper)
        {
            _clockiGoContext = clockiGoContext;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.User?> GetUserByIdAsync(Guid userID)
        { 
            var userEntity = await _clockiGoContext.Users.FirstOrDefaultAsync(u => u.Id ==  userID);
            if (userEntity is null)
                return null;

            var user = _mapper.Map<Domain.Entities.User>(userEntity);

            return user;
        }

        public async Task AddAsync(Domain.Entities.User user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);

            await _clockiGoContext.Users.AddAsync(userEntity);
            await Save();
        }

        public async Task<Domain.Entities.User?> GetUserByEmailAsync(string email)
        {
            var userEntity = await _clockiGoContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (userEntity is null)
                return null;

            var user = _mapper.Map<Domain.Entities.User>(userEntity);

            return user;
        }

        public async Task<bool> UpdateUserAsync(Domain.Entities.User updatedUser)
        {
            var id = updatedUser.Id;
            var oldUserEntity = await _clockiGoContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (oldUserEntity is null)
                return false;

            var updatedUserEntity = _mapper.Map<UserEntity>(updatedUser);

            oldUserEntity = updatedUserEntity;


            _clockiGoContext.Update(oldUserEntity);
            await Save();

            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var userEntity = await _clockiGoContext.Users.FirstOrDefaultAsync(o => o.Id == userId);

            if (userEntity is null)
                return false;

            _clockiGoContext.Users.Remove(userEntity);
            await Save();

            return true;
        }


        private async Task Save()
        {
            await _clockiGoContext.SaveChangesAsync();
        }

    }
}
