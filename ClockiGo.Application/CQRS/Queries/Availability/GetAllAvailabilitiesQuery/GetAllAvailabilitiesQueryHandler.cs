using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Application.Services.Organization.Common;
using ClockiGo.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Queries.Availability.GetAllAvailabilitiesQuery
{
    public class GetAllAvailabilitiesQueryHandler : IRequestHandler<GetAllAvailabilitiesQuery, ErrorOr<GetAllAvailabilitiesResult>>
    {
        private readonly IAvailabilityRepository _availabilityRepository;
        private readonly IUserRepository _userRepository;

        public GetAllAvailabilitiesQueryHandler(IAvailabilityRepository availabilityRepository, IUserRepository userRepository)
        {
            _availabilityRepository = availabilityRepository;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<GetAllAvailabilitiesResult>> Handle(GetAllAvailabilitiesQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.SenderId);
            if (user is null) return Errors.User.UserNotFound;
            if (user.Role != Domain.Enums.Role.Admin) return Errors.User.AccessDenied;

            var organizations = await _availabilityRepository.GetAvailabilitiesAsync();
            if (organizations is null) return Errors.Availability.AvailabilityNotFound;

            return new GetAllAvailabilitiesResult(organizations);

        }
    }
}
