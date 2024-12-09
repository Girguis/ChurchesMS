using System.Net;

namespace ChurchMS.Application.Results;

public sealed class Result<TData> : Result
{
    public TData Data { get; }

    private Result()
    {

    }

    public Result(Exception exception) : base(exception)
    {
    }

    protected Result(HttpStatusCode statusCode, TData data) : base(statusCode)
    {
        Data = data;
    }

    protected Result(HttpStatusCode statusCode, string errorCode) : base(statusCode, errorCode)
    {
    }

    protected Result(HttpStatusCode statusCode, string errorCode, object errors) : base(statusCode, errorCode, errors)
    {
    }

    public static Result<TData> Success(TData data, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new Result<TData>(statusCode, data);
    }

    public static Result<TData> Failure(HttpStatusCode statusCode, string errorCode)
    {
        return new Result<TData>(statusCode, errorCode);
    }

    public static Result<TData> Failure(HttpStatusCode statusCode, string errorCode, object errors)
    {
        return new Result<TData>(statusCode, errorCode, errors);
    }

    public static Result<TData> CreateException(Exception exception)
    {
        return new Result<TData>(exception);
    }
}