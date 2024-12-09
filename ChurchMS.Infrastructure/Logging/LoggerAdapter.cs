using ChurchMS.Application.Contracts.Logging;
using Serilog;

namespace ChurchMS.Infrastructure.Logging;

public class LoggerAdapter(ILogger logger) : IAppLogger
{
    private readonly ILogger _logger = logger;

    public void LogInformation(string message)
    {
        _logger.Information(message);
    }

    public void LogWarning(string message)
    {
        _logger.Warning(message);
    }

    public void LogError(string message, Exception ex)
    {
        _logger.Error(ex, message);
    }
}