using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Application.Services.Organization.Common;
using ClockiGo.Domain.Common.Errors;
using ClockiGo.Domain.Entities;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace ClockiGo.Application.CQRS.Commands.Organization.UpdateOrganizationCommand
{
    public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationCommand, ErrorOr<UpdateOrganizationResult>>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UpdateOrganizationCommandHandler(IOrganizationRepository organizationRepository, IMapper mapper, IUserRepository userRepository)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<UpdateOrganizationResult>> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);
            if (user is null) return Errors.User.UserNotFound;
            if (user.Role != Domain.Enums.Role.Admin) return Errors.User.AccessDenied;

            Domain.Entities.Organization result;
            Guid id = request.OrganizationId;
            var organization = await _organizationRepository.GetOrganizationByIdAsync(id);

            if (organization is null) return Errors.Organization.OrganizationNotFound;
            result = organization;

            organization = _mapper.Map<Domain.Entities.Organization>(request);

            var isSuccess = await _organizationRepository.UpdateOrganizationAsync(organization);
            if (isSuccess) result = organization;
            
            return new UpdateOrganizationResult(result);
        }
    }
}
