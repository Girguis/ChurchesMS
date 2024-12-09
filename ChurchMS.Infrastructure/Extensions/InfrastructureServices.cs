using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChurchMS.Infrastructure.Extensions;

public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMapperSerivce();
        services.AddLoggingService();
        services.AddDocumentService();
        services.AddIdentityService();
        services.AddCipherService();
        services.AddLocalizationService();

        return services;
    }
}