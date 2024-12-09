using ChurchMS.Application.Contracts.Identity;
using ChurchMS.Infrastructure.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ChurchMS.Infrastructure.Extensions;

internal static class IdentityService
{
    internal static IServiceCollection AddIdentityService(this IServiceCollection services)
    {
        services.AddScoped(typeof(ITokenService), typeof(TokenService));

        return services;
    }
}