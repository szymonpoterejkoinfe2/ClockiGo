using FluentValidation;

namespace ClockiGo.Application.CQRS.Queries.Availability.GetAllAvailabilitiesOfUserInMonthOfYearQuery
{
    public class GetAllAvailabilitiesOfUserInMonthOfYearQueryValidator : AbstractValidator<GetAllAvailabilitiesOfUserInMonthOfYearQuery>
    {
        public GetAllAvailabilitiesOfUserInMonthOfYearQueryValidator()
        {
            RuleFor(q => q.UserId).NotEmpty();
            RuleFor(q => q.SenderId).NotEmpty();
            RuleFor(q => q.MonthOfYear).NotEmpty();
        }
    }
}
