using FluentValidation;

namespace ClockiGo.Application.CQRS.Commands.Organization.UpdateOrganizationCommand
{
    public class UpdateOrganizationCommandValidator : AbstractValidator<UpdateOrganizationCommand>
    {
        public UpdateOrganizationCommandValidator()
        {
            RuleFor(o => o.UserId).NotEmpty();
            RuleFor(o => o.OrganizationId).NotEmpty();
            RuleFor(o => o.Email).EmailAddress();
            RuleFor(o => o.Phone.Length).InclusiveBetween(9, 12);
            RuleFor(o => o.Name).NotEmpty();    
        }
    }
}
