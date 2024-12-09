using ChurchMS.Application.Contracts.Persistance;
using ChurchMS.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ChurchMS.Persistence.Extensions;

internal static class DIServices
{
    public static IServiceCollection AddDIServices(this IServiceCollection services)
    {
        services.AddRepositoriesDI();

        return services;
    }

    private static IServiceCollection AddRepositoriesDI(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepo<,>), typeof(GenericRepo<,>));
        services.AddScoped(typeof(ICityRepo), typeof(CityRepo));
        services.AddScoped(typeof(IDistrictRepo), typeof(DistrictRepo));
        services.AddScoped(typeof(IStreetRepo), typeof(StreetRepo));

        return services;
    }
}