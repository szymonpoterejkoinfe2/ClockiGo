using FluentValidation;

namespace ClockiGo.Application.CQRS.Commands.Organization.DeleteOrganizationCommand
{
    public class DeleteOrganizationCommandValidator : AbstractValidator<DeleteOrganizationCommand>
    {
        public DeleteOrganizationCommandValidator()
        {
            RuleFor(o => o.OrganizationId).NotEmpty();
        }
    }
}
