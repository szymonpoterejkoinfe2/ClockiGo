using ClockiGo.Application.Services.Organization.Common;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Queries.Availability.GetAllAvailabilitiesOfUserQuery
{
    public record GetAllAvailabilitiesOfUserQuery
        (
            Guid UserId,
            Guid SenderId
        ) : IRequest<ErrorOr<GetAllAvailabilitiesOfUserResult>>;
}
