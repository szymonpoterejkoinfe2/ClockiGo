using ClockiGo.Application.Services.Organization.Common;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Queries.Organization.GetOrganizationsQuery
{
    public record GetOrganizationsQuery
        () : IRequest<ErrorOr<GetOrganizationsResult>>;
}
