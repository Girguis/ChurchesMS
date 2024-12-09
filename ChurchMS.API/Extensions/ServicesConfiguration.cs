using ChurchMS.API.Middlewares;
using ChurchMS.Application.Contracts.Appsettings;
using ChurchMS.Application.Extensions;
using ChurchMS.Infrastructure.Extensions;
using ChurchMS.Persistence.Extensions;

namespace ChurchMS.API.Extensions;

internal static class ServicesConfiguration
{
    public static WebApplicationBuilder AddServicesConfiguration(this WebApplicationBuilder builder)
    {
        builder.ReadAppsettings();
        builder.Services.AddPersistenceServices(builder.Configuration);
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddApplicationServices();
        builder.Services.AddCors();

        builder.Services.AddTransient<ExceptionMiddleware>();

        return builder;
    }

    private static WebApplicationBuilder ReadAppsettings(this WebApplicationBuilder builder)
    {
        builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>();
        builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStringOptions>();
        builder.Configuration.GetSection("FontOptions").Get<FontOptions>();

        return builder;
    }
}