using ChurchMS.Application.Contracts.Appsettings;
using ChurchMS.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChurchMS.Persistence.Extensions;

internal static class DataContextServices
{
    public static IServiceCollection AddDataContextServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ChurchMSContext>(opt =>
        {
            opt.UseNpgsql(ConnectionStringOptions.DefaultDbConnection);
        });

        return services;
    }
}