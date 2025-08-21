using FluentValidation;

namespace ClockiGo.Application.CQRS.Commands.Organization.AddOrganizationCommand
{
    public class AddOrganizationCommandValidation : AbstractValidator<AddOrganizationCommand>
    {
        public AddOrganizationCommandValidation()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.Phone).MinimumLength(11);
        }
    }
}
