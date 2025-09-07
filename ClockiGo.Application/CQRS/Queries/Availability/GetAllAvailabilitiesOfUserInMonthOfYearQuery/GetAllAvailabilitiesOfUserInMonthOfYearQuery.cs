using ClockiGo.Application.Services.Organization.Common;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Queries.Availability.GetAllAvailabilitiesOfUserInMonthOfYearQuery
{
    public record GetAllAvailabilitiesOfUserInMonthOfYearQuery
        (
            Guid UserId,
            Guid SenderId,
            DateOnly MonthOfYear
        ) : IRequest<ErrorOr<GetAllAvailabilitiesOfUserInMonthOfYearResult>>;
}
