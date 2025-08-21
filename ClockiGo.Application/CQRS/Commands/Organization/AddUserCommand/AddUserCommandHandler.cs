using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Contracts.Organization;
using ClockiGo.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Commands.Organization.AddUserCommand
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, ErrorOr<AddUserResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrganizationRepository _organizationRepository;

        public AddUserCommandHandler(IUserRepository userRepository, IOrganizationRepository organizationRepository)
        {
            _userRepository = userRepository;
            _organizationRepository = organizationRepository;
        }

        public async Task<ErrorOr<AddUserResult>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var userId = request.UserId;
            var organizationId = request.OrganizationId;

            var foundUser = await  _userRepository.GetUserByIdAsync(userId);
            if (foundUser is null)
            {
                return Errors.User.UserNotFound;
            }

            var foundOrganization = await _organizationRepository.GetOrganizationByIdAsync(organizationId);
            if (foundOrganization is null) 
            { 
                return Errors.Organization.OrganizationNotFound;
            }

            var success = await _organizationRepository.AddUser(organizationId,userId);

            return new AddUserResult(Success: success);
        }
    }
}
