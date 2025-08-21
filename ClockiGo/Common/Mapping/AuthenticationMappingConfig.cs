using ClockiGo.Application.Services.Authentication.Common;
using ClockiGo.Contracts.Authentication;
using Mapster;

namespace ClockiGo.Presentation.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(des => des.Token, src => src.Token)
                .Map(des => des , src => src.User);
        }
    }
}
