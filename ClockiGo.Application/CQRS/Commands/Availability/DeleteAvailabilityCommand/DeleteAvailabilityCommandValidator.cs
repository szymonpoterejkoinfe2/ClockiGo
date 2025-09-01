using FluentValidation;

namespace ClockiGo.Application.CQRS.Commands.Availability.DeleteAvailabilityCommand
{
    public class DeleteAvailabilityCommandValidator : AbstractValidator<DeleteAvailabilityCommand>
    {
        public DeleteAvailabilityCommandValidator()
        {
            RuleFor(a => a.AvailabilityId).NotEmpty();
        }
    }
}
