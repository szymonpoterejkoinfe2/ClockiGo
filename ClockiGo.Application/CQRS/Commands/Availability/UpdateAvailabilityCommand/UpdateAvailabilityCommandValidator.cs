using ClockiGo.Domain.Enums;
using FluentValidation;

namespace ClockiGo.Application.CQRS.Commands.Availability.UpdateAvailabilityCommand
{
    public class UpdateAvailabilityCommandValidator : AbstractValidator<UpdateAvailabilityCommand>
    {
        public UpdateAvailabilityCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.AvailabilityType).Must(value => Enum.IsDefined(typeof(AvailabilityType), (int)value));
            RuleFor(c => c.AvailableFrom).NotEmpty();
            RuleFor(c => c.AvailableTo).NotEmpty().GreaterThan(c => c.AvailableFrom);
        }
    }
}
