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

        public UpdateOrganizationCommandHandler(IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<UpdateOrganizationResult>> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Organization result;

            Guid id = request.OrganizationId ?? Guid.Empty;

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
