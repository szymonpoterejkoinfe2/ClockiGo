using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Application.Services.Organization.Common;
using ClockiGo.Domain.Common.Errors;
using ClockiGo.Domain.DTOs;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace ClockiGo.Application.CQRS.Queries.Availability.GetAllAvailabilitiesOfUserInMonthOfYearQuery
{
    public class GetAllAvailabilitiesOfUserInMonthOfYearQueryHandler : IRequestHandler<GetAllAvailabilitiesOfUserInMonthOfYearQuery, ErrorOr<GetAllAvailabilitiesOfUserInMonthOfYearResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAvailabilityRepository _availabilityRepository;
        private readonly IMapper _mapper;

        public GetAllAvailabilitiesOfUserInMonthOfYearQueryHandler(IUserRepository userRepository, IAvailabilityRepository availabilityRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _availabilityRepository = availabilityRepository;
            _mapper = mapper;
        }


        public async Task<ErrorOr<GetAllAvailabilitiesOfUserInMonthOfYearResult>> Handle(GetAllAvailabilitiesOfUserInMonthOfYearQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);
            var sender = await _userRepository.GetUserByIdAsync(request.SenderId);
            if (user is null || sender is null) return Errors.User.UserNotFound;

            if (sender.Id != user.Id && sender.Role != Domain.Enums.Role.Admin)
                return Errors.User.AccessDenied;

            var availabilities = await _availabilityRepository.GetAvailabilitiesOfUserInMonthOfYearAsync(user.Id, request.MonthOfYear);
            var availabilitieDTOs = _mapper.Map<IReadOnlyList<AvailabilityDTO>>(availabilities);

            var result = new GetAllAvailabilitiesOfUserInMonthOfYearResult(availabilitieDTOs);

            return result;
        }
    }
}
