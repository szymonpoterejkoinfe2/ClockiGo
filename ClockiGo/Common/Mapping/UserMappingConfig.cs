using ClockiGo.Domain.DTOs;
using ClockiGo.Domain.Entities;
using Mapster;

namespace ClockiGo.Presentation.Common.Mapping
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, UserDTO>()
                .Map(u => u.Role, ud => (int)ud.Role);
        }
    }
}
