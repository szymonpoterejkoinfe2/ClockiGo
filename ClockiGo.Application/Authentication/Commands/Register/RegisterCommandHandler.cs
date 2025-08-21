using ClockiGo.Application.Common.Interfaces.Authentication;
using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Application.Services.Authentication.Common;
using ClockiGo.Domain.Common.Errors;
using ClockiGo.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : 
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {

            //1. Check if user doesn't exists
            if (await _userRepository.GetUserByEmailAsync(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            //2. Create new user
            var user = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Phone = command.Phone,
                Password = command.Password
            };
            await _userRepository.AddAsync(user);

            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
