using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Application.Services.Organization.Common;
using ClockiGo.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Commands.Organization.DeleteOrganizationCommand
{
    public class DeleteOrganizationCommandHandler : IRequestHandler<DeleteOrganizationCommand, ErrorOr<DeleteOrganizationResult>>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUserRepository _userRepository;

        public DeleteOrganizationCommandHandler(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<ErrorOr<DeleteOrganizationResult>> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);
            if (user is null) return Errors.User.UserNotFound;
            if (user.Role != Domain.Enums.Role.Admin) return Errors.User.AccessDenied;


            var isSuccess = await _organizationRepository.DeleteAsync(request.OrganizationId);

            if (!isSuccess)
                return Errors.Organization.OrganizationNotFound;

            return new DeleteOrganizationResult(true);
        }
    }
}
