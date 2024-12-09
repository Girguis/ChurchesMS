using ChurchMS.Application.Contracts.Ciphers;
using ChurchMS.Infrastructure.Ciphers;
using Microsoft.Extensions.DependencyInjection;

namespace ChurchMS.Infrastructure.Extensions;

internal static class CipherService
{
    internal static IServiceCollection AddCipherService(this IServiceCollection services)
    {
        services.AddSingleton(typeof(ICipher), typeof(Cipher));

        return services;
    }
}