using ClockiGo.Application.Authentication.Commands.Register;
using ClockiGo.Application.Common.Interfaces.Authentication;
using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Application.Services.Authentication.Common;
using ClockiGo.Domain.Common.Errors;
using ClockiGo.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockiGo.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            //1. validate user exists
            if (await _userRepository.GetUserByEmailAsync(query.Email) is not User loginUser)
            {
                return Errors.User.UserNotFound;
            }
            //2. Validate password correct
            if (loginUser.Password != query.Password)
            {
                return new[] { Errors.User.WrongPassword };
            }

            //3. Create JWT Token
            var token = _jwtTokenGenerator.GenerateToken(loginUser);

            return new AuthenticationResult(loginUser, token);
        }
    }
    
}

