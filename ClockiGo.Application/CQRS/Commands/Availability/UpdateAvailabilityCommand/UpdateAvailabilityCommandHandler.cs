using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Application.Services.Organization.Common;
using ClockiGo.Domain.Common.Errors;
using ClockiGo.Domain.Enums;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Commands.Availability.UpdateAvailabilityCommand
{
    public class UpdateAvailabilityCommandHandler : IRequestHandler<UpdateAvailabilityCommand, ErrorOr<UpdateAvailabilityResult>>
    {
        private readonly IAvailabilityRepository _availabilityRepository;
        private readonly IUserRepository _userRepository;

        public UpdateAvailabilityCommandHandler(IAvailabilityRepository availabilityRepository, IUserRepository userRepository)
        {
            _availabilityRepository = availabilityRepository;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<UpdateAvailabilityResult>> Handle(UpdateAvailabilityCommand request, CancellationToken cancellationToken)
        {
            var senderId = request.SenderId;
            var availabilityId = request.Id;

            var sender = await _userRepository.GetUserByIdAsync(senderId);
            if (sender is null)
                return Errors.User.UserNotFound;
            
            var availability = await _availabilityRepository.GetAvailabilityByIdAsync(availabilityId);
           
            if (availability is null) 
                return Errors.Availability.AvailabilityNotFound;

            if(availability.UserId != senderId || sender.Role != Domain.Enums.Role.Admin) 
                return Errors.User.AccessDenied;
            
            availability.AvailableFrom = request.AvailableFrom;
            availability.AvailableTo = request.AvailableTo;
            availability.AvailabilityType = (AvailabilityType)request.AvailabilityType;

            var success = await _availabilityRepository.UpdateAvailabilityAsync(availability);

            return new UpdateAvailabilityResult(success);
        }
    }
}
