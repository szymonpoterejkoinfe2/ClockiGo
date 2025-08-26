using ClockiGo.Application.CQRS.Commands.Organization.UpdateOrganizationCommand;
using ClockiGo.Application.Services.Organization.Common;
using ClockiGo.Contracts.Organization;
using ClockiGo.Domain.Entities;
using Mapster;

namespace ClockiGo.Presentation.Common.Mapping
{
    public class OrganizationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AddOrganizationResult, AddOrganizationResponse>()
                .Map(des => des, src => src.Organization);
            config.NewConfig<UpdateOrganizationResult, UpdateOrganizationResponse>()
                .Map(des => des, src => src.Organization);
            config.NewConfig<UpdateOrganizationCommand, Organization>()
                .Map(des => des.Id, src => src.OrganizationId);

        }
    }
}
