using ClockiGo.Application.Services.Organization.Common;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Queries.Organization.GetOrganizationQuery
{
    public record GetOrganizationQuery
        (
            Guid OrganizationId
        ) : IRequest<ErrorOr<GetOrganizationResult>>;
}
