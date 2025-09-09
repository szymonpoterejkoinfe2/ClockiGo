using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Application.Services.Organization.Common;
using ClockiGo.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Queries.Availability.GetAllAvailabilitiesOfOrganizationQuery
{
    public class GetAllAvailabilitiesOfOrganizationQueryHandler : IRequestHandler<GetAllAvailabilitiesOfOrganizationQuery, ErrorOr<GetAllAvailabilitiesOfOrganizationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IAvailabilityRepository _availabilityRepository;
        public GetAllAvailabilitiesOfOrganizationQueryHandler(IUserRepository userRepository, IOrganizationRepository organizationRepository, IAvailabilityRepository availabilityRepository)
        {
            _userRepository = userRepository;
            _organizationRepository = organizationRepository;
            _availabilityRepository = availabilityRepository;
        }

        public async Task<ErrorOr<GetAllAvailabilitiesOfOrganizationResult>> Handle(GetAllAvailabilitiesOfOrganizationQuery request, CancellationToken cancellationToken)
        {
            var sender = await _userRepository.GetUserByIdAsync(request.SenderId);
            if (sender is null) return Errors.User.UserNotFound;

            var organization = await _organizationRepository.GetOrganizationByIdAsync(request.OrganizationId);
            if (organization is null) return Errors.Organization.OrganizationNotFound;
            if (sender.OrganizationId != organization.Id) return Errors.User.AccessDenied;

            var availabilities = await _availabilityRepository.GetAvailabilitiesOfOrganizationAsync(organization.Id);
            return new GetAllAvailabilitiesOfOrganizationResult(availabilities);
        }
    }
}
