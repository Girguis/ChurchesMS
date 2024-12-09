using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ChurchMS.Application.Extensions;

public static class MapperService
{
    internal static IServiceCollection AddMapperService(this IServiceCollection services)
    {
        services.AddSingleton(sp =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(Assembly.GetExecutingAssembly());
            });

            return config.CreateMapper();
        });

        return services;
    }

    public static void AddMapperService(IMapper mapper)
    {
        ProjectToExtension.SetMapper(mapper);
    }
}
