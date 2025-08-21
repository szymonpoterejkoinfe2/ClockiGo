using FluentValidation;

namespace ClockiGo.Application.CQRS.Commands.Organization.AddUserCommand
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            RuleFor(u => u.UserId).NotEmpty();
            RuleFor(u => u.OrganizationId).NotEmpty();
        }
    }
}
