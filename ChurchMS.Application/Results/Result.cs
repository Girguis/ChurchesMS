using ChurchMS.Application.Constants;
using System.Net;

namespace ChurchMS.Application.Results;

public class Result
{
    public HttpStatusCode StatusCode { get; }
    public string? ErrorCode { get; }
    public object? Errors { get; }
    public Exception Exception { get; }
    public bool IsSuccess => string.IsNullOrEmpty(ErrorCode) && Errors is null && Exception is null;
    public bool IsException => Exception != null || Exception != default;
    public bool IsError => !IsSuccess;

    protected Result()
    {

    }

    protected Result(Exception exception)
    {
        StatusCode = HttpStatusCode.InternalServerError;
        ErrorCode = ErrorCodes.InternalServerError;
        Exception = exception;
    }

    protected Result(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
    }

    protected Result(HttpStatusCode statusCode, string errorCode)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
    }

    protected Result(HttpStatusCode statusCode, string errorCode, object errors)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
        Errors = errors;
    }

    public static Result Success(HttpStatusCode statusCode)
    {
        return new Result(statusCode);
    }

    public static Result Failure(HttpStatusCode statusCode, string errorCode)
    {
        return new Result(statusCode, errorCode);
    }

    public static Result Failure(HttpStatusCode statusCode, string errorCode, object errors)
    {
        return new Result(statusCode, errorCode, errors);
    }

    public static Result CreateException(Exception exception)
    {
        return new Result(exception);
    }
}