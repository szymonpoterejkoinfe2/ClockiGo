using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Application.Services.Organization.Common;
using ClockiGo.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace ClockiGo.Application.CQRS.Commands.Organization.AddOrganizationCommand
{
    public class AddOrganizationCommandHandler : IRequestHandler<AddOrganizationCommand, ErrorOr<AddOrganizationResult>>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;

        public AddOrganizationCommandHandler(IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<AddOrganizationResult>> Handle(AddOrganizationCommand request, CancellationToken cancellationToken)
        {
            if (await _organizationRepository.GetOrganizationByEmailAsync(request.Email) is not null)
            {
                return Errors.Organization.DuplicateEmail;
            }

            var organization = new Domain.Entities.Organization
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone
            };

            await _organizationRepository.AddAsync(organization);

            var result = new AddOrganizationResult(organization);

            return result;  
        }
    }
}
