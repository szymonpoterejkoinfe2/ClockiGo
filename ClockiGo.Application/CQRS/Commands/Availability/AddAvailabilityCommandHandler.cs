using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Application.Services.Availability.Common;
using ClockiGo.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace ClockiGo.Application.CQRS.Commands.Availability
{
    public class AddAvailabilityCommandHandler : IRequestHandler<AddAvailabilityCommand, ErrorOr<AddAvailabilityResult>>
    {
        private readonly IAvailabilityRepository _availabilityRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public AddAvailabilityCommandHandler(IAvailabilityRepository availabilityRepository, IMapper mapper, IOrganizationRepository organizationRepository, IUserRepository userRepository)
        {
            _availabilityRepository = availabilityRepository;
            _mapper = mapper;
            _organizationRepository = organizationRepository;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AddAvailabilityResult>> Handle(AddAvailabilityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (await _userRepository.GetUserByIdAsync(request.UserId) is null)
                {
                    return Errors.User.UserNotFound;
                }

                if(await _organizationRepository.GetOrganizationByIdAsync(request.OrganizationId) is null)
                {
                    return Errors.Organization.OrganizationNotFound;
                }

                var newAvailability = _mapper.Map<Domain.Entities.Availability>(request);
                newAvailability.Id = Guid.NewGuid();

                await _availabilityRepository.AddAsync(newAvailability);

                return new AddAvailabilityResult
                (
                    Success: true,
                    Message: "Availability added successfully!"
                );
            }
            catch (Exception ex)
            {
                return new AddAvailabilityResult
                    (
                        Success: false,
                        Message: ex.InnerException?.Message ?? ex.Message
                    );
            }

        }
    }
}
