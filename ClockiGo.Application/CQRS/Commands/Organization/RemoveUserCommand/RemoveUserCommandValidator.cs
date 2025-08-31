using FluentValidation;

namespace ClockiGo.Application.CQRS.Commands.Organization.RemoveUserCommand
{
    public class RemoveUserCommandValidator : AbstractValidator<RemoveUserCommand>
    {
        public RemoveUserCommandValidator()
        {
            RuleFor(o => o.OrganizationId).NotEmpty();
            RuleFor(o => o.UserId).NotEmpty();   
        }
    }
}
