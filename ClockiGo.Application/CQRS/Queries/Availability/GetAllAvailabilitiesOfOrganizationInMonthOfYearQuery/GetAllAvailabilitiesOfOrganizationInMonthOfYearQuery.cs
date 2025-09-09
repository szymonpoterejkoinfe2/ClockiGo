using ClockiGo.Application.Services.Organization.Common;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Queries.Availability.GetAllAvailabilitiesOfOrganizationInMonthOfYearQuery
{
    public record GetAllAvailabilitiesOfOrganizationInMonthOfYearQuery
    (
        Guid SenderId,
        Guid OrganizationId,
        DateTime MonthOfYear
    ) : IRequest<ErrorOr<GetAllAvailabilitiesOfOrganizationInMonthOfYearResult>>;
}
