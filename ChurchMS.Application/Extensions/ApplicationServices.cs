using ChurchMS.Application.Extensions.MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ChurchMS.Application.Extensions;

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatRService();
        services.AddMapperService();

        return services;
    }
}