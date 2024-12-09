namespace ChurchMS.API.Extensions;

internal static class CorsService
{
    internal static IServiceCollection AddCorsService(this IServiceCollection services)
    {
        services.AddCors(opt =>
        {
            opt.AddDefaultPolicy(cfg =>
            {
                cfg.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            });
        });

        return services;
    }
}