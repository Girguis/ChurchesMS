using ChurchMS.Application.Contracts.Logging;
using ChurchMS.Infrastructure.Logging;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Formatting.Json;
using System.Text;

namespace ChurchMS.Infrastructure.Extensions;

internal static class LoggingService
{
    internal static IServiceCollection AddLoggingService(this IServiceCollection services)
    {
        Log.Logger = new LoggerConfiguration()
                            .WriteTo.File(new JsonFormatter(),
                                            "Logs/.json",
                                            rollingInterval: RollingInterval.Day,
                                            encoding: Encoding.UTF8)
                            .CreateLogger();

        services.AddSingleton(Log.Logger);
        services.AddScoped(typeof(IAppLogger), typeof(LoggerAdapter));

        return services;
    }
}