using FluentValidation;

namespace ClockiGo.Application.CQRS.Queries.Availability.GetAllAvailabilitiesQuery
{
    public class GetAllAvailabilitiesQueryValidator : AbstractValidator<GetAllAvailabilitiesQuery>
    {
        public GetAllAvailabilitiesQueryValidator()
        {
            RuleFor(q => q.SenderId).NotEmpty();
        }
    }
}
