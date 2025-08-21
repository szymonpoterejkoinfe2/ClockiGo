using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Application.Services.Organization.Common;
using ClockiGo.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Queries.Organization.GetOrganizationQuery
{
    public class GetOrganizationQueryHandler : IRequestHandler<GetOrganizationQuery, ErrorOr<GetOrganizationResult>>
    {
        private readonly IOrganizationRepository _organizationRepository;

        public GetOrganizationQueryHandler(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<ErrorOr<GetOrganizationResult>> Handle(GetOrganizationQuery request, CancellationToken cancellationToken)
        {
            var id = request.OrganizationId;

            var organization = await _organizationRepository.GetOrganizationByIdAsync(id);

            if (organization is null) return Errors.Organization.OrganizationNotFound;

            return new GetOrganizationResult(organization);

        }
    }
}
