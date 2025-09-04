using FluentValidation;

namespace ClockiGo.Application.CQRS.Queries.Availability.GetAllAvailabilitiesOfUserQuery
{
    public class GetAllAvailabilitiesOfUserQueryValidator : AbstractValidator<GetAllAvailabilitiesOfUserQuery>
    {
        public GetAllAvailabilitiesOfUserQueryValidator()
        {
            RuleFor(q => q.UserId).NotEmpty();
            RuleFor(q => q.SenderId).NotEmpty();
        }
    }
}
