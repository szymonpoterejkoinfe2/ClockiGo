using ClockiGo.Application.Services.Organization.Common;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Queries.Availability.GetAllAvailabilitiesQuery
{
    public record GetAllAvailabilitiesQuery
        (
            Guid SenderId
        ) : IRequest<ErrorOr<GetAllAvailabilitiesResult>>;
}
