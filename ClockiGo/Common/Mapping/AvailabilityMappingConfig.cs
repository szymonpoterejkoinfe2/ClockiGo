using ClockiGo.Application.CQRS.Commands.Availability;
using ClockiGo.Application.Services.Availability.Common;
using ClockiGo.Contracts.Availability;
using ClockiGo.Domain.Entities;
using ClockiGo.Domain.Enums;
using ClockiGo.Infrastructure.Presistance.Entities;
using Mapster;

namespace ClockiGo.Presentation.Common.Mapping
{
    public class AvailabilityMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AddAvailabilityRequest, AddAvailabilityCommand>()
                 .Map(des => des.UserId, src => src.UserId)
                 .Map(des => des.OrganizationId, src => src.OrganizationId)
                 .Map(des => des.AvailabilityType, src => src.AvailabilityType)
                 .Map(des => des.AvailabilityFrom, src => src.AvailabilityFrom)
                 .Map(des => des.AvailabilityTo, src => src.AvailabilityTo);

            config.NewConfig<AddAvailabilityCommand, Availability>()
                .Map(des => des.UserId, src => src.UserId)  
                .Map(des => des.OrganizationId, src => src.OrganizationId)
                .Map(des => des.AvailabilityType, src => (AvailabilityType)src.AvailabilityType)
                .Map(des => des.AvailableFrom, src => src.AvailabilityFrom)
                .Map(des => des.AvailableTo, src => src.AvailabilityTo);

            config.NewConfig<Availability, AvailabilityEntity>()
                .Map(des => des.AvailabilityType, src => (byte)src.AvailabilityType)
                .Map(des => des.AvailableFrom, src => src.AvailableFrom)
                .Map(des => des.AvailableTo, src => src.AvailableTo)
                .Map(des => des.UserId, src => src.UserId)
                .Map(des => des.OrganizationId, src => src.OrganizationId);

            config.NewConfig<AvailabilityEntity, Availability>()
                .Map(des => des.AvailabilityType, src => (AvailabilityType)src.AvailabilityType)
                .Map(des => des.AvailableFrom, src => src.AvailableFrom)
                .Map(des => des.AvailableTo, src => src.AvailableTo)
                .Map(des => des.UserId, src => src.UserId)
                .Map(des => des.OrganizationId, src => src.OrganizationId);

            config.NewConfig<AddAvailabilityResult, AddAvailabilityResponse>()
                .Map(des => des.Success, src => src.Success)
                .Map(des => des.Message, src => src.Message);

        }
    }
}
