using ChurchMS.Application.Contracts.Appsettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChurchMS.Persistence.Extensions;

public static class PersistenceServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataContextServices(configuration);
        services.AddDIServices();

        return services;
    }
}