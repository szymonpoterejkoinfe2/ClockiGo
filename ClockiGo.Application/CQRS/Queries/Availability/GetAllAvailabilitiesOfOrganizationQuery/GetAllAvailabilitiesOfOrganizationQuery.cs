using ClockiGo.Application.Services.Organization.Common;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Queries.Availability.GetAllAvailabilitiesOfOrganizationQuery
{
    public record GetAllAvailabilitiesOfOrganizationQuery
    (
        Guid SenderId,
        Guid OrganizationId
    ) : IRequest<ErrorOr<GetAllAvailabilitiesOfOrganizationResult>>;
}
