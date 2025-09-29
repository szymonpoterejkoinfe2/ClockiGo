using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Application.Services.Organization.Common;
using ClockiGo.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Commands.User.DeleteUserCommand
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ErrorOr<DeleteUserResult>>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<DeleteUserResult>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);
            if (user is null) return Errors.User.UserNotFound;

            if (request.UserId != request.SenderId)
            {
                var sender = await _userRepository.GetUserByIdAsync(request.SenderId);
                if (sender is null || sender.Role != Domain.Enums.Role.Admin)
                    return Errors.User.AccessDenied;
            }

            var result = await _userRepository.DeleteUserAsync(user.Id);

            return new DeleteUserResult(result);
        }
    }
}
