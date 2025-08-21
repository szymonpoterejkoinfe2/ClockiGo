using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Application.Services.Organization.Common;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Queries.Organization.GetOrganizationsQuery
{
    public class GetOrganizationsQueryHandler : IRequestHandler<GetOrganizationsQuery, ErrorOr<GetOrganizationsResult>>
    {
        private readonly IOrganizationRepository _organizationRepository;

        public GetOrganizationsQueryHandler(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<ErrorOr<GetOrganizationsResult>> Handle(GetOrganizationsQuery request, CancellationToken cancellationToken)
        {
            var organizations = await _organizationRepository.GetOrganizationsAsync();

            return new GetOrganizationsResult(Organizations: organizations);
        }
    }
}
