using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Application.Services.Organization.Common;
using ClockiGo.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Queries.Availability.GetAllAvailabilitiesOfUserQuery
{
    public class GetAllAvailabilitiesOfUserQueryHandler : IRequestHandler<GetAllAvailabilitiesOfUserQuery, ErrorOr<GetAllAvailabilitiesOfUserResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAvailabilityRepository _availabilityRepository;

        public GetAllAvailabilitiesOfUserQueryHandler(IUserRepository userRepository, IAvailabilityRepository availabilityRepository)
        {
            _userRepository = userRepository;
            _availabilityRepository = availabilityRepository;
        }

        public async Task<ErrorOr<GetAllAvailabilitiesOfUserResult>> Handle(GetAllAvailabilitiesOfUserQuery request, CancellationToken cancellationToken)
        {
            var sender = await _userRepository.GetUserByIdAsync(request.SenderId);
            if (sender is null) return Errors.User.UserNotFound;

            var user = await _userRepository.GetUserByIdAsync(request.UserId);
            if (user is null) return Errors.User.UserNotFound;

            if (sender.Id != user.Id)
            {
                if (sender.Role != Domain.Enums.Role.Admin) return Errors.User.AccessDenied;
            }

            var availabilities = await _availabilityRepository.GetAvailabilitiesOfUserAsync(user.Id);
            if (availabilities is null) return Errors.Availability.AvailabilityNotFound;

            return new GetAllAvailabilitiesOfUserResult(availabilities);
        }
    }
}
