using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Application.Services.Organization.Common;
using ClockiGo.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Commands.Availability.DeleteAvailabilityCommand
{
    public class DeleteAvailabilityCommandHandler : IRequestHandler<DeleteAvailabilityCommand, ErrorOr<DeleteAvailabilityResult>>
    {
        private readonly IAvailabilityRepository _availabilityRepository;

        public DeleteAvailabilityCommandHandler(IAvailabilityRepository availabilityRepository)
        {
            _availabilityRepository = availabilityRepository;
        }

        public async Task<ErrorOr<DeleteAvailabilityResult>> Handle(DeleteAvailabilityCommand request, CancellationToken cancellationToken)
        {
            var availabilityId = request.AvailabilityId;

            var availability = await _availabilityRepository.GetAvailabilityByIdAsync(availabilityId);
            if (availability is null) return Errors.Availability.AvailabilityNotFound;
            if (availability.UserId != request.UserId) return Errors.User.AccessDenied;

            var result = await _availabilityRepository.DeleteAsync(availabilityId);

            return new DeleteAvailabilityResult(result);

        }
    }
}
