using FluentValidation;

namespace ClockiGo.Application.CQRS.Queries.Availability.GetAllAvailabilitiesOfOrganizationQuery
{
    public class GetAllAvailabilitiesOfOrganizationQueryValidator : AbstractValidator<GetAllAvailabilitiesOfOrganizationQuery>
    {
        public GetAllAvailabilitiesOfOrganizationQueryValidator()
        {
            RuleFor(q => q.SenderId).NotEmpty();
            RuleFor(q => q.OrganizationId).NotEmpty();
        }
    
    }
}
