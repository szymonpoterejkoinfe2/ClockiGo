using FluentValidation;

namespace ClockiGo.Application.CQRS.Queries.Organization.GetOrganizationQuery
{
    public class GetOrganizationQueryValidator : AbstractValidator<GetOrganizationQuery>
    {
        public GetOrganizationQueryValidator()
        {
            RuleFor(o => o.OrganizationId).NotEmpty();
        }
    }
}
