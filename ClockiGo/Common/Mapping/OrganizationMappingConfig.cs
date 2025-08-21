using ClockiGo.Application.Services.Organization.Common;
using ClockiGo.Contracts.Organization;
using Mapster;

namespace ClockiGo.Presentation.Common.Mapping
{
    public class OrganizationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AddOrganizationResult, AddOrganizationResponse>()
                .Map(des => des, src => src.Organization);

            
        }
    }
}
