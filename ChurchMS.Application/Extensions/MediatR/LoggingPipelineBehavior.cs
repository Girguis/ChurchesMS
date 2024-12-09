using ChurchMS.Application.Constants;
using ChurchMS.Application.Contracts.Logging;
using ChurchMS.Application.Results;
using MediatR;

namespace ChurchMS.Application.Extensions.MediatR;

public class LoggingPipelineBehavior<TRequest, TResponse>(IAppLogger logger) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IAppLogger _logger = logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Start Request {typeof(TRequest).Name}");

        var result = await next();
        if (result is Result resultObj && resultObj.IsException)
            _logger.LogError(ErrorCodes.InternalServerError, resultObj.Exception);

        _logger.LogInformation($"End Request {typeof(TRequest).Name}");

        return result;
    }
}