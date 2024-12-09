using ChurchMS.Application.Contracts.Mapper;
using ChurchMS.Infrastructure.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace ChurchMS.Infrastructure.Extensions;

internal static class MapperSerivce
{
    internal static IServiceCollection AddMapperSerivce(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IGMapper), typeof(GMapper));

        return services;
    }
}