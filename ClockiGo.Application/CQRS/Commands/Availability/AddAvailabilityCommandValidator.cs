using ClockiGo.Domain.Enums;
using FluentValidation;

namespace ClockiGo.Application.CQRS.Commands.Availability
{
    public class AddAvailabilityCommandValidator : AbstractValidator<AddAvailabilityCommand>
    {
        public AddAvailabilityCommandValidator()
        {
            RuleFor(a => a.UserId).NotEmpty();
            RuleFor(a => a.OrganizationId).NotEmpty();
            RuleFor(a => a.AvailabilityType).Must(value => Enum.IsDefined(typeof(AvailabilityType), (int)value));
            RuleFor(a => a.AvailabilityFrom).NotEmpty().LessThan(a => a.AvailabilityTo);
            RuleFor(a => a.AvailabilityTo).NotEmpty().GreaterThan(a => a.AvailabilityFrom);
        }
    }
}
