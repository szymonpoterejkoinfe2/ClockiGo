using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Application.Services.Organization.Common;
using ClockiGo.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace ClockiGo.Application.CQRS.Commands.Organization.RemoveUserCommand
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand, ErrorOr<RemoveUserResult>>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RemoveUserCommandHandler(IOrganizationRepository organizationRepository, IUserRepository userRepository, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<RemoveUserResult>> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var userId = request.UserId;
            var user = await _userRepository.GetUserByIdAsync(userId);

            if (user is null) return Errors.User.UserNotFound;

            var organizationId = request.OrganizationId;
            var organization = await _organizationRepository.GetOrganizationByIdAsync(organizationId);

            if (organization is null) return Errors.Organization.OrganizationNotFound;

            var result = await _organizationRepository.RemoveUser(organizationId, userId);

            return new RemoveUserResult(result);
        }
    }
}
