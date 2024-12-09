using ChurchMS.Application.Common.Dtos.Response;
using ChurchMS.Application.Constants;
using ChurchMS.Application.Contracts.Logging;
using System.Net;

namespace ChurchMS.API.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    private readonly IAppLogger _logger;

    public ExceptionMiddleware(IAppLogger logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var responseBody = System.Text.Json.JsonSerializer.Serialize(new ErrorDto()
            {
                ErrorCode = ErrorCodes.InternalServerError
            });

            _logger.LogError($"error during executing {context.Request.Path.Value}", ex);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(responseBody);
        }
    }
}