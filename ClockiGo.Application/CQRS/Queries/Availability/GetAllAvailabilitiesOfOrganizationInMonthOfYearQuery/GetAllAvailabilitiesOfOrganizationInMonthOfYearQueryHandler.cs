using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Application.Services.Organization.Common;
using ClockiGo.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Queries.Availability.GetAllAvailabilitiesOfOrganizationInMonthOfYearQuery
{
    public class GetAllAvailabilitiesOfOrganizationInMonthOfYearQueryHandler : IRequestHandler<GetAllAvailabilitiesOfOrganizationInMonthOfYearQuery, ErrorOr<GetAllAvailabilitiesOfOrganizationInMonthOfYearResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IAvailabilityRepository _availabilityRepository;

        public GetAllAvailabilitiesOfOrganizationInMonthOfYearQueryHandler(IUserRepository userRepository, IOrganizationRepository organizationRepository, IAvailabilityRepository availabilityRepository)
        {
            _userRepository = userRepository;
            _organizationRepository = organizationRepository;
            _availabilityRepository = availabilityRepository;
        }

        public async Task<ErrorOr<GetAllAvailabilitiesOfOrganizationInMonthOfYearResult>> Handle(GetAllAvailabilitiesOfOrganizationInMonthOfYearQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.SenderId);
            if (user is null) return Errors.User.UserNotFound;

            var organization = await _organizationRepository.GetOrganizationByIdAsync(request.OrganizationId);
            if (organization is null) return Errors.Organization.OrganizationNotFound;
            if (organization.Id != user.OrganizationId) return Errors.User.AccessDenied;

            DateOnly monthOfYear = DateOnly.FromDateTime(request.MonthOfYear);

            var availabilities = await _availabilityRepository.GetAvailabilitiesOfOrganizationInMonthOfYearAsync(organization.Id, monthOfYear);

            return new GetAllAvailabilitiesOfOrganizationInMonthOfYearResult
                (
                    Availabilities: availabilities
                );
        }
    }
}
