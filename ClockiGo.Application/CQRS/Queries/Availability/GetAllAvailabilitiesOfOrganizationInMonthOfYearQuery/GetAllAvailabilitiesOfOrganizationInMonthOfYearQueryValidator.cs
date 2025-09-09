using FluentValidation;

namespace ClockiGo.Application.CQRS.Queries.Availability.GetAllAvailabilitiesOfOrganizationInMonthOfYearQuery
{
    public  class GetAllAvailabilitiesOfOrganizationInMonthOfYearQueryValidator : AbstractValidator<GetAllAvailabilitiesOfOrganizationInMonthOfYearQuery>
    {
        public GetAllAvailabilitiesOfOrganizationInMonthOfYearQueryValidator()
        {
            RuleFor(q => q.SenderId).NotEmpty();
            RuleFor(q => q.OrganizationId).NotEmpty();
            RuleFor(q => q.MonthOfYear).NotEmpty();
        }
    }
}
