using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Application.Services.Organization.Common;
using ClockiGo.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Commands.Organization.DeleteOrganizationCommand
{
    public class DeleteOrganizationCommandHandler : IRequestHandler<DeleteOrganizationCommand, ErrorOr<DeleteOrganizationResult>>
    {
        private readonly IOrganizationRepository _organizationRepository;

        public DeleteOrganizationCommandHandler(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<ErrorOr<DeleteOrganizationResult>> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
        {
            var isSuccess = await _organizationRepository.DeleteAsync(request.OrganizationId);

            if (!isSuccess)
                return Errors.Organization.OrganizationNotFound;

            return new DeleteOrganizationResult(true);
        }
    }
}
